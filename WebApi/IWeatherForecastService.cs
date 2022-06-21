using System.Collections.Generic;

namespace WebApi
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
