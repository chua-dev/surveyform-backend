using SurveyForm.Data;
using SurveyForm.Interfaces;
using SurveyForm.Models;

namespace SurveyForm.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly DataContext _dataContext;

        public SurveyRepository(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        public int CreateSurveryAndRetreiveId(Survey survey)
        {
            var mySurvey = survey;
            _dataContext.Surveys.Add(mySurvey);
            if (Save()) 
            { 
                return mySurvey.Id;
            } else
            {
                throw new NotImplementedException();
            };
        }

        public bool CreateSurvey(Survey survey)
        {
            // add, updating, modifying
            _dataContext.Add(survey);
            return Save();
        }



        public ICollection<Survey> GetSurveys()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            // take all action in the context & CONVERT TO SQL to insert into db, take changes
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
