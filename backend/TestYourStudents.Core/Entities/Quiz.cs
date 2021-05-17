using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public class Quiz : BaseEntity
    {
        public List<Question> Questions { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public uint NumberOfMinutes { get; set; }

        public bool VisibleForStudents { get; set; }
        
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
        public virtual List<QuizSubmission> Submissions { get; set; }
    }
}