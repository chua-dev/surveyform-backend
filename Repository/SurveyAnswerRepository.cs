using Microsoft.EntityFrameworkCore;
using SurveyForm.Data;
using SurveyForm.Interfaces;
using SurveyForm.Models;

namespace SurveyForm.Repository
{
    public class SurveyAnswerRepository : ISurveyAnswerRepository
    {
        private readonly DataContext _dataContext;

        public SurveyAnswerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Survey> GetSurveyAnswers()
        {
            return _dataContext.Surveys.Include(s => s.SurveyAnswers)
                .ToList();
        }
    }
}
