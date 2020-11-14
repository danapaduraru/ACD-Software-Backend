using Microsoft.AspNetCore.Mvc;
using Models.Interview;
using Models.ModelHelper.RelationshipDTOs;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterviewsController : Controller
    {
        private readonly IInterviewsService _interviewsService;

        public InterviewsController(IInterviewsService interviewsService)
        {
            _interviewsService = interviewsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _interviewsService.GetAllAsync();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            var result = await _interviewsService.GetByIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("GetByPersonId/{id?}")]
        public async Task<IActionResult> GetByPersonId(Guid? id)
        {
            var result = await _interviewsService.GetByPersonIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
        
        [HttpGet("GetByApplicationId/{id?}")]
        public async Task<IActionResult> GetByApplicationId(Guid? id)
        {
            var result = await _interviewsService.GetByApplicationIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddInterviewDTO addInterviewsDTO)
        {
            var result = await _interviewsService.AddAsync(addInterviewsDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost("AddTestToInterview")]
        public async Task<IActionResult> AddTestToInterview([FromBody] TestsToInterviewsRelationDTO testsToInterviewsRelationDTO)
        {
            var result = await _interviewsService.AddTestToInterviewAsync(testsToInterviewsRelationDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(Guid? id, [FromBody] UpdateInterviewDTO updateInterviewDTO)
        {
            var result = await _interviewsService.UpdateAsync((Guid)id, updateInterviewDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
