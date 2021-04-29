using System.Collections.Generic;

namespace TestYourStudents.Core.Entities
{
    public class QuizSubmission: BaseEntity
    {
       public List<QuestionResponse> Responses { get; set; }
    }
}