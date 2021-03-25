using System.ComponentModel.DataAnnotations;

namespace TestYourStudents.API.Requests
{
    public class ProfessorRequest
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Phone { get; set; }
    }
}