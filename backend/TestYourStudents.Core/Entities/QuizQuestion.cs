using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuizQuestion: BaseEntity
    {
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
    }
}