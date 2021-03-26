using System.Collections.Generic;

namespace TestYourStudents.Core.Identity.Utils
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }

        public int UserType { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}