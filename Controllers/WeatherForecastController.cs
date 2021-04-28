using API_exploration.Contract;
using API_exploration.DTOs;
using API_exploration.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public WeatherForecastController(IModelContract modelContract, IMapper mapper)
        {
            _modelContract = modelContract;
            _mapper = mapper;
        }

        // private readonly MockModelContract _modelContract = new MockModelContract();
        [HttpGet("GetWhateverItReturns")] // used to be "GetWhaterverItReturnsMocked" with the typo
        public ActionResult <IEnumerable<WhateverReadDTO>> GetWhateverItReturns() // old return type was <IEnumerable<WeatherForecast>> // used to be GetWhateverItReturnsMocked
        {
            var whatevers = _modelContract.GetWhateverItReturns();
            return Ok(_mapper.Map<IEnumerable<WhateverReadDTO>>(whatevers)); // old return used to be Ok(whatevers)
        }

        [HttpGet("{id}")]
        public ActionResult <WhateverReadDTO> GetOneById(int id) // used to be <WeatherForecast // used to be GetOneByIdMocked
        {
            var getById = _modelContract.GetOneById(id); // it makes a difference, an error is returned when a non int is used
            if (getById != null)
            {
                return Ok(_mapper.Map<WhateverReadDTO>(getById)); // used to be (getById)
            }
            return NotFound();
        }

        [HttpGet("GetWhateverItReturnsUnchanged")] // used to be "GetWhaterverItReturnsMocked" with the typo
        public ActionResult<IEnumerable<WeatherForecast>> GetWhateverItReturnsUnchanged() // old return type was <IEnumerable<WeatherForecast>> // used to be GetWhateverItReturnsMocked
        {
            var whatevers = _modelContract.GetWhateverItReturns();
            return Ok(whatevers); // old return used to be Ok(whatevers)
        }

        [HttpPost]
        public ActionResult<WhateverReadDTO> CreateWhatever(WhateverCreateDTO whateverCreateDTO)
        {
            if (whateverCreateDTO.TemperatureC > 60)
            {
                return BadRequest(new { error = "The temperature cannot be higher than 60" });
            } else if (whateverCreateDTO.TemperatureC < -100)
            {
                return BadRequest(new { error = "The temperature cannot be lower than -100" });
            } else if (whateverCreateDTO.RainChance > 100)
            {
                return BadRequest(new { error = "Rain chance cannot be greater than 100%" });
            } else if (whateverCreateDTO.RainChance < 0)
            {
                return BadRequest(new { error = "Rain chance cannot be lower than 0 per cent." });
            }
            var initialModel = _mapper.Map<InitialModel>(whateverCreateDTO);
            _modelContract.CreateWhatever(initialModel);
            _modelContract.SaveChanges();

            return Ok(initialModel);
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
