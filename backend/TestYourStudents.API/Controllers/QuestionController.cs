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
    [Route("/api/{courseId}/question")]
    public class QuestionController : ControllerBase
    {
        private readonly IRepository<Quiz> _quizRepo;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<Question> _questionRepo;

        public QuestionController(IRepository<Quiz> quizRepo, IRepository<Course> courseRepo, IRepository<Question> questionRepo)
        {
            _quizRepo = quizRepo;
            _courseRepo = courseRepo;
            _questionRepo = questionRepo;
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> QuestionCreation([FromBody] CreateQuestionRequest request, [FromRoute] int courseId)
        {

            var course = await _courseRepo.GetByIdAsync(courseId);

            if (course == null)
            {
                return BadRequest("The course does not exist in this scope");
            }


            var userId = User.Claims.Where(c => c.Type.Equals("userId"))?.FirstOrDefault()?.Value;
                
            if (course.ProfessorId != userId)
            {
                return BadRequest("The User ID does not match the Professor's ID");
            }
            
            var quiz = await _quizRepo.GetByIdAsync(request.QuizId);

            if (quiz == null)
            {
                return BadRequest("The quiz does not exist in this scope");
            }

            var question = new Question()
            {
                QuestionName=request.Name,
                QuizId = request.QuizId,
                CreatedByUserId = userId,
                Created = DateTime.Now,
            };
            
            await _questionRepo.AddAsync(question);
            await _questionRepo.SaveChangesAsync();
            
            return Ok(question);
        }

        [HttpDelete]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeleteQuestion([FromBody] DeleteQuestionRequest request, [FromRoute] int courseId)
        {
            
            var course = await _courseRepo.GetByIdAsync(courseId);

            if (course == null)
            {
                return BadRequest("The course is not in this scope");
            }
            
            var userId = User.Claims.Where(c => c.Type.Equals("userId"))?.FirstOrDefault()?.Value;
                
            if (course.ProfessorId != userId)
            {
                return BadRequest("The User ID does not match the Professor's ID");
            }

            var question = await _questionRepo.GetByIdAsync(request.QuestionId);

            if (question == null)
            {
                return BadRequest("The question does not exist at this course");
            }

            await _questionRepo.DeleteAsync(request.QuestionId);
            await _questionRepo.SaveChangesAsync();
            
            return Ok();
        }
    }
}