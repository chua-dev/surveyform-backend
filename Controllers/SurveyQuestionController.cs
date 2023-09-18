using Microsoft.AspNetCore.Mvc;
using SurveyForm.Interfaces;
using SurveyForm.Models;

namespace SurveyForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyQuestionController : Controller
    {
        private readonly ISurveyQuestionsRepository _surveyQuestionsRepository;

        public SurveyQuestionController(ISurveyQuestionsRepository surveyQuestionRepository) 
        {
            _surveyQuestionsRepository = surveyQuestionRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SurveyQuestion>))]
        public IActionResult GetSurveyQuestions()
        {
            var surveyQuestions = _surveyQuestionsRepository.GetSurveyQuestions();

            // form of validation
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(surveyQuestions);
        }
    }
}
