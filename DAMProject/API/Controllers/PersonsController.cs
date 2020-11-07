using Microsoft.AspNetCore.Mvc;
using Models.Person;
using Services.Interfaces;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPersonDTO personDTO)
        {
            var result = await _personsService.AddAsync(personDTO);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
