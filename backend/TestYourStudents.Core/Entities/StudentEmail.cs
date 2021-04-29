
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class StudentEmail : BaseEntity
    {
        public string Email { get; set; }
        
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}