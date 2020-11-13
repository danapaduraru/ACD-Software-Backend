using Microsoft.AspNetCore.Mvc;
using Models.Interview;
using Services.Interfaces;
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
    }
}
