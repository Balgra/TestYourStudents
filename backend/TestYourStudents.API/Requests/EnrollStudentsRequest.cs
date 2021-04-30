using System.Collections.Generic;

namespace TestYourStudents.API.Requests
{
    public class EnrollStudentsRequest
    {
        public List<string> StudentEmails { get; set; }
    }
}