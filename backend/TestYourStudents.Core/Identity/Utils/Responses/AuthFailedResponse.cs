using System.Collections.Generic;

namespace TestYourStudents.Core.Identity.Utils.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}