using Microsoft.AspNetCore.Mvc;
using Models.Application;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsService _applicationsService;

        public ApplicationsController(IApplicationsService applicationService)
        {
            _applicationsService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddApplicationDTO applicationDTO)
        {
            var result = await _applicationsService.AddAsync(applicationDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _applicationsService.GetAllAsync();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            var result = await _applicationsService.GetByIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("jobid/{id?}")]
        public async Task<IActionResult> GetByJobId(Guid? id)
        {
            var result = await _applicationsService.GetAllByJobIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("applicationid/{id?}")]
        public async Task<IActionResult> GetByApplicationId(Guid? id)
        {
            var result = await _applicationsService.GetAllByApplicantIdAsync((Guid)id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(Guid? id, [FromBody] UpdateApplicationDTO application)
        {
            var result = await _applicationsService.UpdateAsync((Guid)id, application);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
