using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class QuizSession : BaseEntity
    {
        public DateTime StartTime { get; set; }
        
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        
        [ForeignKey("User")]
        public string StudentId { get; set; }
       
        public User User { get; set; }
    }
}