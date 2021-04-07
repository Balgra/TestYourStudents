using System.ComponentModel.DataAnnotations;

namespace TestYourStudents.Core.Identity.Utils
{
    public class UserLoginRequest
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

    }
}