using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class Course: BaseEntity
    {
        public string Name { get; set; }
        
        [ForeignKey("User")]
        public string ProfessorId { get; set; }
        
        public User User { get; set; }
        
        [InverseProperty("Course")]
        public virtual ICollection<StudentEmail> StudentEmails { get; set; }
        
    }
}