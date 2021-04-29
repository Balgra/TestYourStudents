using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuizGrade: BaseEntity
    {
        public float Grade { get; set; }
        
        [ForeignKey("QuizSubmissionId")]
        public QuizSubmission QuizSubmission { get; set; }
       
        public int QuizSubmissionId { get; set; }
    }
}