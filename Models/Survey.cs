﻿namespace SurveyForm.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public DateTime SubmitTime { get; set; }
        public List<SurveysAnswer> SurveyAnswers { get; set; }
    }
}
