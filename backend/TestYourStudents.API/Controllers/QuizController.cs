
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using TestYourStudents.API.Requests;
using TestYourStudents.Core.Entities;
using TestYourStudents.EF.EFRepositories.Abstractions;

namespace TestYourStudents.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/{courseId}/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<Quiz> _quizRepo;
        private readonly IRepository<Question> _questionRepo;
        private readonly IRepository<QuizSubmission> _submissionRepo;

        public QuizController(IRepository<Course> courseRepo, IRepository<Quiz> quizRepo, IRepository<Question> questionRepo, IRepository<QuizSubmission> submissionRepo)
        {
            _courseRepo = courseRepo;
            _quizRepo = quizRepo;
            _questionRepo = questionRepo;
            _submissionRepo = submissionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizzes([FromRoute] int courseId)
        {
            var userRole = User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            List<Quiz> quizes;
            
            if (userRole == "Professor")
            {
                quizes = await _quizRepo.AsDbSet().Include(q => q.Questions)
                    .Include(q => q.Course)
                    .Include(q => q.Submissions)
                    .ThenInclude(s => s.Responses)
                    .Where(q => q.CourseId == courseId).ToListAsync();
            }
            else
            {
                quizes = await _quizRepo.AsDbSet()
                    .Include(q => q.Course)
                    .Include(q => q.Submissions)
                    .ThenInclude(s => s.Responses)
                    .Where(q => q.VisibleForStudents && q.CourseId == courseId)
                    .ToListAsync();
            }

            return Ok(quizes);
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

        [HttpPost("submit")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> SubmitQuiz([FromBody] SubmitQuizRequest request, [FromRoute] int courseId)
        {
            var course = await _courseRepo.GetByIdAsync(courseId);

            if (course is null)
            {
                return BadRequest("The course does not exist");
            }

            var quiz = await _quizRepo.GetByIdAsync(request.QuizId);

            if (quiz == null)
            {
                return BadRequest("The quiz is not used in this scope");
            }

            var userId = User.Claims.Where(c => c.Type.Equals("userId"))?.FirstOrDefault()?.Value;

            List<QuestionResponse> responses=new List<QuestionResponse>();
            
            foreach (var response in request.Responses)
            {
                var question = await _questionRepo.GetByIdAsync(response.QuestionId);

                if (question != null)
                {
                    var questionResponse = new QuestionResponse()
                    {
                        QuestionId = response.QuestionId,
                        Response = response.QuestionResponse,
                        CreatedByUserId = userId,
                        Created = DateTime.Now,
                        
                    };
                    
                    responses.Add(questionResponse);
                }
            }
            
            var submission = new QuizSubmission()
            {
                StudentId= userId,
                Responses = responses,
                CreatedByUserId = userId,
                Created = DateTime.Now,
                QuizId = request.QuizId
            };  
            
            await _submissionRepo.AddAsync(submission);
            await _submissionRepo.SaveChangesAsync();
            
            return Ok(submission);
        }

    }

}