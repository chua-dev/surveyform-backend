
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using SurveyForm.Data;
using SurveyForm.Interfaces;
using SurveyForm.Models;
using SurveyForm.RqModel;
using System;
using System.Linq;

namespace SurveyForm.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly DataContext _dataContext;

        public SurveyController(ISurveyRepository surveyRepository, DataContext dataContext) 
        {
            _surveyRepository = surveyRepository;
            _dataContext = dataContext;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateSurvey([FromBody] SurveyRequestModel surveyCreate)
        {
            if (surveyCreate == null)
                return BadRequest(ModelState);

            var survey = new Survey
            {
                SubmitTime = surveyCreate.SubmitDate,
                SurveyAnswers = surveyCreate.SurveyAnswers.Select(answerInput => new SurveysAnswer
                {
                    Answer = answerInput.Answer
                }).ToList()
            };

            _dataContext.Surveys.Add(survey);
            _dataContext.SaveChanges();

            return Ok("Survey created successfully");

        }
    }
}
