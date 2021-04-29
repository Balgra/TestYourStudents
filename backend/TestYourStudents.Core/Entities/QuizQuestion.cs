using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuizQuestion: BaseEntity
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}