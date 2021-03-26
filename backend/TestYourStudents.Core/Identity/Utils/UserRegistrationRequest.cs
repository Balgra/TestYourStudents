using System.ComponentModel.DataAnnotations;

namespace TestYourStudents.Core.Identity.Utils
{
    public class UserRegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}