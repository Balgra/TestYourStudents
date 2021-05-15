using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestYourStudents.API.Responses.Models;
using TestYourStudents.Core.Entities;
using TestYourStudents.EF.EFRepositories.Abstractions;

namespace TestYourStudents.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/courses")]
    public class CourseController: ControllerBase
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<StudentEmail> _studentEmailRepo;

        public CourseController(IRepository<Course> courseRepo, IRepository<StudentEmail> studentEmailRepo)
        {
            _courseRepo = courseRepo;
            _studentEmailRepo = studentEmailRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var userRole = User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value;
            if (userRole == "Professor")
            {
                var userId = User.Claims.Where(c => c.Type.Equals("userId"))?.FirstOrDefault()?.Value;
                var course = await _courseRepo.AsDbSet().Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.ProfessorId == userId);
                return Ok(new CourseResponseModel()
                    {Id = course.Id, Name = course.Name, ProfessorName = course.User.ToString()});
            }

            if (userRole == "Student")
            {

                var userEmail = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;

                var course = await _studentEmailRepo.AsDbSet()
                    .Include(c => c.Course)
                    .Where(s => s.Email == userEmail).Select(s =>
                        new CourseResponseModel()
                            {Id = s.Course.Id, Name = s.Course.Name, ProfessorName = s.Course.User.ToString()})
                    .FirstOrDefaultAsync();

                return Ok(course);
            }

            return BadRequest();

        }
    }
}