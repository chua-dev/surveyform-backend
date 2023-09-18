using SurveyForm.Models;

namespace SurveyForm.Interfaces
{
    public interface ISurveyAnswerRepository
    {
        ICollection<Survey> GetSurveyAnswers();
    }
}
