using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuizSession : BaseEntity
    {
        public DateTime StartTime { get; set; }
        
        public int QuizId { get; set; }
        
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
    }
}