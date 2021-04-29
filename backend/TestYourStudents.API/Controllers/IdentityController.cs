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
    [Microsoft.AspNetCore.Components.Route("api/Identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IRepository<Course> _repo;

        public IdentityController(IIdentityRepository identityRepository, IRepository<Course> repo)
        {
            _identityRepository = identityRepository;
            _repo = repo;
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
            await _repo.AddAsync(course);
            await _repo.SaveChangesAsync();

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