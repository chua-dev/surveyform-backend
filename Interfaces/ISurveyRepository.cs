using SurveyForm.Models;

namespace SurveyForm.Interfaces
{
    public interface ISurveyRepository
    {
        ICollection<Survey> GetSurveys();

        bool CreateSurvey(Survey survey);
    }
}
