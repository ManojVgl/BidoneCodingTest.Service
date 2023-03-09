using BidoneCodingTest.Domain.TestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BidoneCodingTest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidOneTestController : ControllerBase
    {
        private readonly ILogger<BidOneTestController> _logger;
        public BidOneTestController(ILogger<BidOneTestController>  logger
            
            ) {

            _logger = logger;
        }


        // GET: api/<BidOneTestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BidOneTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BidOneTestController>
        [HttpPost("SaveProfile")]
        public  async Task<IActionResult> SaveProfile([FromBody] Profile profile )
        {
            _logger.LogInformation("SaveProfile...Start");
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("SaveProfile...failed");
                return BadRequest("Error");
            }
            _logger.LogInformation(JsonConvert.SerializeObject(profile));
            _logger.LogInformation("SaveProfile...End");
            var result = "The profile has been saved";
            return Ok(result);
        }

        // PUT api/<BidOneTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BidOneTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
