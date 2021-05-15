using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestYourStudents.API.Requests;
using TestYourStudents.Core.Entities;
using TestYourStudents.EF.EFRepositories.Abstractions;
using System.Linq;
using System.Security.Claims;

namespace TestYourStudents.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Professor")]
    [Route("/api/{courseId}/enroll")]
    public class EnrollController : ControllerBase
    {
        private readonly IRepository<StudentEmail> _repo;
        private readonly IRepository<Course> _courseRepo;

        public EnrollController(IRepository<StudentEmail> repo, IRepository<Course> courseRepo)
        {
            _repo = repo;
            _courseRepo = courseRepo;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollStudents([FromBody] EnrollStudentsRequest request, [FromRoute] int courseId)
        {
            // getting the course from db
            var course = await _courseRepo.GetByIdAsync(courseId);

            // checking if the course exist, otherwise stop the process
            if (course is null)
                return BadRequest("The course provided does not exist!");

            var userId = User.Claims.Where(c => c.Type.Equals("userId"))?.FirstOrDefault()?.Value;

            if (!course.ProfessorId.Equals(userId))
                return BadRequest("You are not allowed to add students to that course!");


            // get the students
            var students = await _repo.GetAllAsync();

            // filter already added students for a specific course
            var studentsEmailsAlreadyAdded = from student in students
                                             where request.StudentEmails.Contains(student.Email) && student.CourseId.Equals(courseId)
                                             select student.Email;

            // add the students and skip students that already exist
            foreach (var studentEmail in request.StudentEmails)
            {
                if (!studentsEmailsAlreadyAdded.Any(s => s.Equals(studentEmail)))
                {
                    var studentEmailEntity = new StudentEmail()
                    {
                        Email = studentEmail,
                        CourseId = courseId,
                        Created = DateTime.Now,
                        CreatedByUserId = userId
                    };
                    await _repo.AddAsync(studentEmailEntity);
                }

            }

            await _repo.SaveChangesAsync();

            return Ok("Students enrolled successfully!");
        }
    }
}