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
    public class EnrollController: ControllerBase
    {
        private readonly IRepository<StudentEmail> _repo;

        public EnrollController(IRepository<StudentEmail> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollStudents([FromBody] EnrollStudentsRequest request, [FromRoute] int courseId)
        {
            
            var students = await _repo.GetAllAsync();
            var studentsAlreadyAdded = from student in students
                where request.StudentEmails.Contains(student.Email)
                select student;
            foreach (var studentEmail in request.StudentEmails)
            {
                if (!studentsAlreadyAdded.Any(s => s.Email.Equals(studentEmail)))
                {
                    var studentEmailEntity = new StudentEmail()
                    {
                        Email = studentEmail,
                        CourseId = courseId,
                        Created = DateTime.Now,
                        CreatedByUserId = User.Claims.Where(c => c.Type.Equals("userId"))?.FirstOrDefault()?.Value
                    };
                    await _repo.AddAsync(studentEmailEntity);
                }
            
            }

            await _repo.SaveChangesAsync();

            return Ok();
        }
    }
}