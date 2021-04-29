using System.Collections.Generic;
using TestYourStudents.Core.Entities;

namespace TestYourStudents.Core.Identity.Utils
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        
        public User User { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}