using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestYourStudents.Core.Entities;
using TestYourStudents.Core.Identity.Repository;
using TestYourStudents.Core.Identity.Utils;
using TestYourStudents.Core.Identity.Utils.Responses;

namespace TestYourStudents.API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/Identity")]
    [ApiController]

    public class IdentityController: ControllerBase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly UserManager<User> _userManager;

        public IdentityController(IIdentityRepository identityRepository, UserManager<User> userManager)
        {
            _identityRepository = identityRepository;
            _userManager = userManager;
        }
        
        
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(a => a.ErrorMessage))
                });
            }

            var authResponse = await _identityRepository.RegisterAsync(request);

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

        

    }
}