using System.Threading.Tasks;
using ClientFactories.Factories.Consumers.Implementation;
using ClientFactories.Factories.Consumers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatternsController : ControllerBase
    {
        private readonly IConsumerHandler _consumerHandler;

        public PatternsController(IConsumerHandler consumerHandler)
        {
            _consumerHandler = consumerHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = new BigDataRequest()
            {
                Input = "1"
            };
            var result = await _consumerHandler.ExecuteRequest<BigDataRequest, BigDataResponse>(request);
            return Ok(JsonConvert.SerializeObject(result));
        }
    }
}
