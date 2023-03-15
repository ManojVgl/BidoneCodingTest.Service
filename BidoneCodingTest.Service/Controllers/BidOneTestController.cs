using BidoneCodingTest.Domain.TestModel;
using CodingTest.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BidoneCodingTest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidOneTestController : ControllerBase
    {
        private readonly ILogger<BidOneTestController> _logger;
        private readonly IServices<ProfileService> _services   ;
        public BidOneTestController(ILogger<BidOneTestController>  logger, IServices<ProfileService> services) {
            _logger = logger;
            _services = services;
        }


        // GET: api/<BidOneTestController>
        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            return  _services.Service.FindAll();

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
           
            //log the file
       
                _logger.LogInformation(JsonConvert.SerializeObject(profile));
                _logger.LogInformation("SaveProfile...End");
            //var result = "The profile has been saved";
            //return Ok(result);

            //Save to liteDB
            _services.Service.Insert(profile);

            //save to

            string json = System.Text.Json.JsonSerializer.Serialize(profile);
            var size = json.Length * sizeof(Char);

            if (size < 20000)
            {
                string filePath = @"C:\Temp";
                string fileName = Path.GetRandomFileName();
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, fileName)))
                        await outputFile.WriteAsync(json);
                    return Ok();
                }
                catch (Exception)
                {
                    //INSERT LOGGING CODE HERE - TO CAPTURE THE EXCEPTION
                    return BadRequest("Unspecified create error"); //Purposely being ambiguous or obfuscating the actual error and file path.
                }
            }
            else
                return BadRequest("Error: Malformed data sent.");
           
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
