using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestYourStudents.API.Requests;
using TestYourStudents.API.Responses;
using TestYourStudents.Core.Entities;
using TestYourStudents.Core.Identity.Repository;
using TestYourStudents.Core.Identity.Utils;
using TestYourStudents.Core.Identity.Utils.Responses;
using TestYourStudents.EF.EFRepositories.Abstractions;

namespace TestYourStudents.API.Controllers
{
    [ApiController]
    [Route("/api/Identity/")]

    public class IdentityController : ControllerBase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<StudentEmail> _studentEmailRepo;

        public IdentityController(IIdentityRepository identityRepository, IRepository<Course> courseRepo,
            IRepository<StudentEmail> studentEmailRepo)
        {
            _identityRepository = identityRepository;
            _courseRepo = courseRepo;
            _studentEmailRepo = studentEmailRepo;
        }


        [HttpPost("RegisterAsProfessor")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsProfessor([FromBody] ProfessorRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(a => a.ErrorMessage))
                });
            }

            var authResponse = await _identityRepository.RegisterAsync(request, "Professor");

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            var course = new Course()
            {
                Name = request.CourseName,
                User = authResponse.User,
                Created = DateTime.Now,
                CreatedByUser = authResponse.User
            };
            await _courseRepo.AddAsync(course);
            await _courseRepo.SaveChangesAsync();

            return Ok(new AuthSuccessResponse()
            {
                Token = authResponse.Token
            });
        }


        [HttpPost("RegisterAsStudent")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsStudent([FromBody] UserRegistrationRequest request)
        {
            var studentEmails = await _studentEmailRepo.GetAllAsync();

            var student = from studentEmail in studentEmails
                          where request.Email.Equals(studentEmail.Email)
                          select studentEmail;

            if (student.Count() < 0)
            {
                return BadRequest($"Couldn't find a student enrolled with the email {request.Email}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(a => a.ErrorMessage))
                });
            }

            var authResponse = await _identityRepository.RegisterAsync(request, "Student");

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse()
            {
                Token = authResponse.Token
            });
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityRepository.LoginAsync(request.Email, request.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }

        private async Task<RegisterAsProfessor> Register(UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            var authResponse = await _identityRepository.RegisterAsync(request, "Professor");

            if (!authResponse.Success)
            {
                return null;
            }

            return new RegisterAsProfessor()
            {
                AuthSuccessResponse = new AuthSuccessResponse
                {
                    Token = authResponse.Token,
                },
                Professor = authResponse.User
            };
        }
    }
}