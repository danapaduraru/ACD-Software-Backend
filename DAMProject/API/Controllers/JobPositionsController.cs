using Microsoft.AspNetCore.Mvc;
using Models.JobPosition;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobPositionsController : ControllerBase
    {
        private readonly IJobPositionsService _jobPositionsService;

        public JobPositionsController(IJobPositionsService jobPositionsService)
        {
            _jobPositionsService = jobPositionsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddJobPositionDTO jobPositionDTO)
        {
            var result = await _jobPositionsService.AddAsync(jobPositionDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _jobPositionsService.GetAllAsync();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            var result = await _jobPositionsService.GetByIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var result = await _jobPositionsService.DeleteAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(Guid? id, [FromBody] AddJobPositionDTO jobPositionDTO)
        {
            var result = await _jobPositionsService.UpdateAsync((Guid)id, jobPositionDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
