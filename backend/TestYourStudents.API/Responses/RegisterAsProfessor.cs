using TestYourStudents.Core.Entities;
using TestYourStudents.Core.Identity.Utils.Responses;

namespace TestYourStudents.API.Responses
{
    public class RegisterAsProfessor
    {
        public AuthSuccessResponse AuthSuccessResponse { get; set; }
        public User Professor { get; set; }
    }
}