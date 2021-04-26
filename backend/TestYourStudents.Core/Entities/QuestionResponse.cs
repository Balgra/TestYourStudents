using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuestionResponse : BaseEntity
    {
        [ForeignKey ("QuestionId")]
        public Question Question { get; set; }
        
        public int QuestionId { get; set; }

        public string Response { get; set; }
        public string Feedback { get; set; }

    }
}