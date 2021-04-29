using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuizSubmission: BaseEntity
    {
       public List<QuestionResponse> Responses { get; set; }
       
       [ForeignKey("User")]
       public string StudentId { get; set; }
       
       public User User { get; set; }
    }
}