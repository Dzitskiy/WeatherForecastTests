using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace Tests
{
    public class WeatherForecastStub : IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                //Date = DateTime.Now.AddDays(index),
                TemperatureC = 25,
                Summary = "Test"
            })
                .ToArray();
        }
    }
}
