using API_exploration.Contract;
using API_exploration.DTOs;
using API_exploration.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [HttpGet("{id}", Name = "GetOneById")] // this Name attribute could cause some issues with async programming
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
            } else if (whateverCreateDTO.Location == "")
            {
                return BadRequest(new { error = "Location field must not be empty." });
            } else if (whateverCreateDTO.Summary == "")
            {
                return BadRequest(new { error = "Summary field must not be empty." });
            } else if (whateverCreateDTO.SubmittedBy == "")
            {
                return BadRequest(new { error = "SubmittedBy field must not be empty." });
            }
            var initialModel = _mapper.Map<InitialModel>(whateverCreateDTO);
            _modelContract.CreateWhatever(initialModel);
            _modelContract.SaveChanges();

            var InitialModelReadDTO = _mapper.Map<WhateverReadDTO>(initialModel);

            return CreatedAtRoute(nameof(GetOneById), new { id = InitialModelReadDTO.id }, InitialModelReadDTO); 
            // return Ok(InitialModelReadDTO); // used to be Ok(initialModel) but it also responded back with the SubmittedBy field
        }

        [HttpPut]
        public ActionResult<WhateverReadDTO> PutWhatever(WhateverUpdateDTO whateverUpdateDTO)
        {
            var initialModel = _mapper.Map<InitialModel>(whateverUpdateDTO);
            _modelContract.UpdateWhatever(initialModel);

            var InitialModelUpdateDTO = _mapper.Map<WhateverReadDTO>(initialModel);
            _modelContract.SaveChanges();

            return Ok(InitialModelUpdateDTO);
        }

        [HttpPut("{id}")]
        public ActionResult PutWhatever(int id, WhateverUpdateDTO whateverUpdateDTO)
        {
            var getOneByIdFromRepo = _modelContract.GetOneById(id);
            if (getOneByIdFromRepo == null)
            {
                return BadRequest(new { error = "No content available" });
            }

            _mapper.Map(whateverUpdateDTO, getOneByIdFromRepo);

            _modelContract.UpdateWhatever(getOneByIdFromRepo);  // not really needed in this implementation

            _modelContract.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchWhatever(int id, JsonPatchDocument<WhateverUpdateDTO> jsonPatchDocument)
        {
            var getOneByIdFromRepo = _modelContract.GetOneById(id);
            if (getOneByIdFromRepo == null)
            {
                return BadRequest(new { error = "No content available" });
            }

            var WhateverToPatch = _mapper.Map<WhateverUpdateDTO>(getOneByIdFromRepo);
            jsonPatchDocument.ApplyTo(WhateverToPatch, ModelState);

            if (!TryValidateModel(jsonPatchDocument))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(WhateverToPatch, getOneByIdFromRepo);

            _modelContract.UpdateWhatever(getOneByIdFromRepo); // not really needed in this implementation

            _modelContract.SaveChanges();

            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteWhatever(int id)
        {
            Boolean resourceDeleted = true;

            while (resourcePresent)
            {
                var getOneByIdFromRepo = _modelContract.GetOneById(id);

                if (getOneByIdFromRepo == null && resourcePresent)
                {
                    return BadRequest(new { error = "No content available" });
                } else if {
                    _modelContract.DeleteWhatever(getOneByIdFromRepo);
                }
            }
            /*
            var getOneByIdFromRepo = _modelContract.GetOneById(id);
            
            if (getOneByIdFromRepo == null)
            {
                return BadRequest(new { error = "No content available" });
            }
            _modelContract.DeleteWhatever(getOneByIdFromRepo);
            */


            
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
