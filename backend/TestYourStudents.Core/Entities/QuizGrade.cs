using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuizGrade: BaseEntity
    {
        public float Grade { get; set; }
        
        public QuizSubmission QuizSubmission { get; set; }
        
        [ForeignKey("QuizSubmission")]
        public int QuizSubmissionId { get; set; }
    }
}