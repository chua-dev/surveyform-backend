namespace SurveyForm.Models
{
    public class SurveysAnswer
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public string Answer { get; set; }
    }
}
