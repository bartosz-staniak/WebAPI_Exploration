using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Stormy"
        };

        private static readonly string[] Cities = new[]
        {
            "Tokio", "Sydney", "New York", "London"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                id = rng.Next(0, 10000),
                Date = DateTime.Now.AddDays(index),
                Location = Cities[rng.Next(Cities.Length)],
                TemperatureC = rng.Next(-20, 55),
                RainChance = rng.Next(0, 90),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetTwenty()
        {
            var rng = new Random();
            return Enumerable.Range(1, 20).Select(index => new WeatherForecast
            {
                id = rng.Next(0, 10000),
                Date = DateTime.Now.AddDays(index),
                Location = Cities[rng.Next(Cities.Length)],
                TemperatureC = rng.Next(-20, 55),
                RainChance = rng.Next(0, 90),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
