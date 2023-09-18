using SurveyForm.Data;
using SurveyForm.Interfaces;
using SurveyForm.Models;

namespace SurveyForm.Repository
{
    public class SurveyQuestionsRepository : ISurveyQuestionsRepository
    {
        private readonly DataContext _dataContext;

        public SurveyQuestionsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<SurveyQuestion> GetSurveyQuestions()
        {
            return _dataContext.SurveyQuestions.OrderBy(p => p.Id).ToList(); // Tolist help change to icollection
        }
    }
}
