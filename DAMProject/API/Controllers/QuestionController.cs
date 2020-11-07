using Microsoft.AspNetCore.Mvc;
using Models.Question;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddQuestionDTO questionDTO)
        {
            var result = await _questionsService.AddAsync(questionDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _questionsService.GetAllAsync();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetByID(Guid? id)
        {
            var result = await _questionsService.GetByIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
