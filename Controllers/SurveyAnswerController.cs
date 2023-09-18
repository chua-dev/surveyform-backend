using Microsoft.AspNetCore.Mvc;
using SurveyForm.Interfaces;
using SurveyForm.Models;

namespace SurveyForm.Controllers
{
    [Route("api/answers")]
    [ApiController]
    public class SurveyAnswerController : Controller
    {
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;

        public SurveyAnswerController(ISurveyAnswerRepository repo)
        {
            _surveyAnswerRepository = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Survey>))]
        public IActionResult GetSurveyAnswers()
        {
            var surveyAnswers = _surveyAnswerRepository.GetSurveyAnswers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(surveyAnswers);
        }
    }
}
