﻿
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestYourStudents.API.Requests;
using TestYourStudents.Core.Entities;
using TestYourStudents.EF.EFRepositories.Abstractions;

namespace TestYourStudents.API.Controllers
{
    [ApiController]
    [Authorize(Roles="Professor")]
    [Route("/api/{courseId}/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<Quiz> _quizRepo;

        public QuizController(IRepository<Course> courseRepo, IRepository<Quiz> quizRepo)
        {
            _courseRepo = courseRepo;
            _quizRepo = quizRepo;
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> QuizCreation([FromBody] CreateQuizRequest request, [FromRoute] int courseId)
        {

            var course = await _courseRepo.GetByIdAsync(courseId);

            if (course is null)
            {
                return BadRequest("The course does not exist");
            }
            
            var userId = User.Claims.Where(c => c.Type.Equals("userId"))?.FirstOrDefault()?.Value;

            if (!course.ProfessorId.Equals(userId))
            {
                return BadRequest("The Professor is not teaching this course!");
            }

            if (request.StartTime < DateTime.Now)
            {
                return BadRequest("A quiz can not start in the past");
            }

            if (request.EndTime < request.StartTime)
            {
                return BadRequest("Can not create quiz with end time small than start time");
            }

            var quiz = new Quiz()
            {
                Name = request.Name,
                StartTime=request.StartTime,
                EndTime = request.EndTime,
                NumberOfMinutes = request.NumberOfMinutes,
                VisibleForStudents=request.VisibleForStudents,
                Created=DateTime.Now,
                CreatedByUserId = userId,
                CourseId = courseId,
            };

            await _quizRepo.AddAsync(quiz);
            await _quizRepo.SaveChangesAsync();
            
            

            return Ok(quiz);

        }
        
    }

}