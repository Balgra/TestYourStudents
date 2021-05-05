using System;

namespace TestYourStudents.API.Requests
{
    public class CreateQuizRequest
    {
        public string Name { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public uint NumberOfMinutes { get; set; }

        public bool VisibleForStudents { get; set; }
        
        
    }
}