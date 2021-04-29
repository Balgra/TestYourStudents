using System.ComponentModel.DataAnnotations;
using TestYourStudents.Core.Identity.Utils;

namespace TestYourStudents.API.Requests
{
    public class ProfessorRegistrationRequest: UserRegistrationRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string CourseName { get; set; }
    }
}