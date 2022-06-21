using System.Collections.Generic;

namespace WebApplication3
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
