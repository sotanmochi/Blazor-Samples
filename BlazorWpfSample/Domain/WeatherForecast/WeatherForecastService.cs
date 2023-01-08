using System;
using System.Threading.Tasks;

namespace BlazorWpfSample.Domain
{
    public class WeatherForecastService
    {
        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            return await Task.FromResult(SampleData);
        }
        
        private readonly WeatherForecast[] SampleData = new[]
        {
            new WeatherForecast()
            {
                Date = new DateOnly(2022, 1, 6),
                TemperatureC = 1,
                Summary = "Freezing",
            },
            new WeatherForecast()
            {
                Date = new DateOnly(2022, 1, 7),
                TemperatureC = 14,
                Summary = "Bracing",
            },
            new WeatherForecast()
            {
                Date = new DateOnly(2022, 1, 8),
                TemperatureC = -13,
                Summary = "Freezing",
            },
            new WeatherForecast()
            {
                Date = new DateOnly(2022, 1, 9),
                TemperatureC = -16,
                Summary = "Balmy",
            },
            new WeatherForecast()
            {
                Date = new DateOnly(2022, 1, 10),
                TemperatureC = -2,
                Summary = "Chilly",
            }
        };
    }
}