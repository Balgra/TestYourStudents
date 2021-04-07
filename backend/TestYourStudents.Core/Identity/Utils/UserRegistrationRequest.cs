using System.ComponentModel.DataAnnotations;

namespace TestYourStudents.Core.Identity.Utils
{
    public class UserRegistrationRequest
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
    }
}