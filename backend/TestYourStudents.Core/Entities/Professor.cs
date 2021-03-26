using System.ComponentModel.DataAnnotations;

namespace TestYourStudents.Core.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Phone { get; set; }
    }
}