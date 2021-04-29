using System;
using System.Collections.Generic;

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
        
        
    }
}