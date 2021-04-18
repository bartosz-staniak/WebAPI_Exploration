using API_exploration.Contract;
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

        private readonly IModelContract _modelContract;
        public WeatherForecastController(IModelContract modelContract)
        {
            _modelContract = modelContract;
        }

        // private readonly MockModelContract _modelContract = new MockModelContract();
        [HttpGet("GetWhaterverItReturnsMocked")]
        public ActionResult <IEnumerable<WeatherForecast>> GetWhateverItReturns() // used to be GetHwateverItReturnsMocked
        {
            var whatevers = _modelContract.GetWhateverItReturns();
            return Ok(whatevers);
        }

        [HttpGet("{id}")]
        public ActionResult <WeatherForecast> GetOneByIdMocked(int id)
        {
            var getById = _modelContract.GetOneById(id); // it makes a difference, an error is returned when a non int is used
            return Ok(getById);
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Stormy"
        };

        private static readonly string[] Cities = new[]
        {
            "Tokio", "Sydney", "New York", "London"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        /*
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        */

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

        [HttpGet("GetTwenty")]
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
