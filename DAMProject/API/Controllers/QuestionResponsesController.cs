using Microsoft.AspNetCore.Mvc;
using Models.Question;
using Models.QuestionResponse;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionResponsesController : ControllerBase
    {
        private readonly IQuestionResponsesService _questionResponsesService;

        public QuestionResponsesController(IQuestionResponsesService questionResponsesService)
        {
            _questionResponsesService = questionResponsesService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddQuestionResponseDTO questionResponsesDTO)
        {
            var result = await _questionResponsesService.AddAsync(questionResponsesDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _questionResponsesService.GetAllAsync();

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
            var result = await _questionResponsesService.GetByIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet]
        //[Route("AllResponsesForTest/{interviewid?}/{testid?}")]
        [Route("AllResponsesForTest")]
        public async Task<IActionResult> GetAllResponsesForSpecificTest([FromQuery] Guid? interviewid, [FromQuery] Guid? testid)
        {
            var result = await _questionResponsesService.GetAllResponsesForSpecificTestAsync((Guid)interviewid, (Guid)testid);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
        [HttpGet]
        //[Route("ResponsesForQuestion/{interviewid?}/{testid?}/{questionid?}")]
        [Route("ResponsesForQuestion")]
        public async Task<IActionResult> GetResponseForQuestion([FromQuery] Guid? interviewid,[FromQuery] Guid? testid,[FromQuery] Guid? questionId)
        {
            var result = await _questionResponsesService.GetResponseForQuestionAsync((Guid)interviewid, (Guid)testid, (Guid)questionId);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
