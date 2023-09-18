using SurveyForm.Models;

namespace SurveyForm.Interfaces
{
    public interface ISurveyQuestionsRepository
    {
        ICollection<SurveyQuestion> GetSurveyQuestions();
    }
}
