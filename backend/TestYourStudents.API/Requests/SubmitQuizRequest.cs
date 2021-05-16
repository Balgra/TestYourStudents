using System.Collections.Generic;
using TestYourStudents.Core.Entities;

namespace TestYourStudents.API.Requests
{
    public class SubmitQuizRequest
    {
        public int QuizId { get; set; }

        public List<QuestionResponseRequest> Responses { get; set; }
    }

    public class QuestionResponseRequest
    {
        public int QuestionId { get; set; }

        public string QuestionResponse { get; set; }
    }
}