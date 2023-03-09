using Moq;

namespace BidOne.Tests
{

    using BidoneCodingTest.Domain;
    using BidoneCodingTest.Domain.TestModel;
    using BidoneCodingTest.Service.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    public class BidOneTestAPIController
    {

        private readonly Mock<Logger<BidOneTestController>>  logger;
        public BidOneTestAPIController()
        {
            
        }
        [Fact]
        public async void SaveProfile()
        {

            var mock = new Mock<ILogger<BidOneTestController>>();
            ILogger<BidOneTestController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<BidOneTestController>>();
            var bidoneTestController = new BidOneTestController(logger);
            Profile profile = new Profile(){
                   FirstName= "Manoj",
                   LastName= "Madhavan"
                };

            //act
            var Result = await  bidoneTestController.SaveProfile(profile) as OkObjectResult; ;

            //assert
            Assert.NotNull(profile);
            Assert.Equal(Result.Value, "The profile has been saved");
            
        }
    }
}