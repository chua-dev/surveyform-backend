namespace SurveyForm.RqModel
{
    public class SurveyRequestModel
    {
        public DateTime SubmitDate { get; set; }
        public List<AnswerRequestModel> SurveyAnswers { get; set; }
    }
}
