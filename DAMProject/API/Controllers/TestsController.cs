using Microsoft.AspNetCore.Mvc;
using Models.Question;
using Models.Test;
using Models.ModelHelpers;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ITestsService _testsService;

        public TestsController(ITestsService testsService)
        {
            _testsService = testsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTestDTO testDTO)
        {
            var result = await _testsService.AddAsync(testDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _testsService.GetAllAsync();

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
            var result = await _testsService.GetByIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        [Route("AddQuestionToTest")]
        public async Task<IActionResult> AddQuestionToTest([FromBody] TestToQuestionsRelationDTO testToQuestDTO)
        {
            var result = await _testsService.AddQuestionToTestAsync(testToQuestDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

    }
}
