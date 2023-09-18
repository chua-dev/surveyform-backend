using SurveyForm.Data;
using SurveyForm.Models;

namespace SurveyForm
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            // If there is no any question yet
            if (!dataContext.SurveyQuestions.Any())
            {
                var surveryQuestions = new List<SurveyQuestion>()
                {
                    new SurveyQuestion() { Question = "My First question"},
                    new SurveyQuestion() { Question = "My Second Question"},
                    new SurveyQuestion() { Question = "My Third Question"},
                };


                dataContext.SurveyQuestions.AddRange(surveryQuestions);
                dataContext.SaveChanges();
            }
        }
    }
}
