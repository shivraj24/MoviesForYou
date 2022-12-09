using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        [HttpPost("addProducer")]
        public async Task<IActionResult> AddProducer(Producer producer)
        {
            return Ok("Success");
        }

        [HttpPut("updateProducer")]
        public async Task<IActionResult> UpdateProducer(Producer producer)
        {
            return Ok("Success");
        }
    }
}
