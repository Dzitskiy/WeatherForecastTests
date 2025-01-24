using Moq;
using Newtonsoft.Json;
using System.Linq;
using WebApi;
using WebApi.Controllers;
using Xunit;

namespace Tests
{
    public class WeatherForecastTests
    {

        [Fact]
        public void WeatherForecastController_GetData_Failed()
        {
            var weatherForecastStab = new WeatherForecastStub();
            WeatherForecastController controller = new WeatherForecastController(weatherForecastStab/*new WeatherForecastStub()*/);

            var controllerData = controller.Get();
            var stubData = weatherForecastStab.Get();

            Assert.NotEqual(controllerData, stubData);
        }

        [Fact]
        public void WeatherForecastController_GetData_Success()
        {

            Mock<IWeatherForecastService> mock = new Mock<IWeatherForecastService>();

            var weatherForecastStab = new WeatherForecastStub();
            WeatherForecastController controller = new WeatherForecastController(mock.Object);

            mock.Setup(_ => _.Get()).Returns(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                //Date = DateTime.Now.AddDays(index),
                TemperatureC = 25,
                Summary = "Test"
            }));

            var controllerData = controller.Get();
            var stubData = weatherForecastStab.Get();

            Assert.NotEqual(controllerData, stubData);

            //var controllerData = controller.Get().FirstOrDefault().TemperatureF;
            //var stubData = weatherForecastStab.Get().FirstOrDefault().TemperatureF;

            var object1Json = JsonConvert.SerializeObject(controllerData);
            var object2Json = JsonConvert.SerializeObject(stubData);

            Assert.Equal(object1Json, object2Json);
        }

        //https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
        [Theory]
        //[InlineData(1)]
        [InlineData(2)]
        //[InlineData(3)]
        [InlineData(4)]
        public void WeatherForecastController_GetData_CheckCode(int code)
        {
            Assert.True(code % 2 == 0);
        }
    }   
}
