using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesForYou.Application.API.Interfaces;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerServices producerServices;
        public ProducersController(IProducerServices _producerServices)
        {
            this.producerServices = _producerServices;
        }
        [HttpPost("addProducer")]
        public async Task<IActionResult> AddProducer(Producer producer)
        {
            var isSuccessful = await producerServices.AddProducerAsync(producer);
            return Ok("Success");
        }

        [HttpPut("updateProducer")]
        public async Task<IActionResult> UpdateProducer(Producer producer)
        {
            var isSuccessful = await producerServices.UpdateProducerAsync(producer);
            return Ok("Success");
        }
        [HttpGet("producers")]
        public async Task<ActionResult<List<Producer>>> GetAllProducerAsync()
        {
            return await producerServices.GetAllProducersAsync();
        }

    }
}
