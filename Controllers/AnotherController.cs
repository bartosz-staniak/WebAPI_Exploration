using API_exploration.Contract;
using API_exploration.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnotherController : ControllerBase
    {
        private readonly IAnotherModelContract _anotherContract;
        private readonly IMapper _mapper;

        public AnotherController(IAnotherModelContract anotherContract)
        {
            _anotherContract = anotherContract;
        }

        //api/another/
        [HttpGet("{location}")]
        public ActionResult<Locations> GetLocationByName(string location)
        {
            var getByLocation = _anotherContract.GetOneLocationByName(location);
            if (getByLocation != null)
            {
                return Ok(getByLocation);
            }
            return NotFound();
        }

        //api/Another
        [HttpGet]
        public ActionResult<IEnumerable<Locations>> Get()
        {
            var anotherLocations = _anotherContract.GetAllLocations();
            return Ok(anotherLocations);
        }

        [HttpPut("{location}")] // location name
        public ActionResult PutAnother(string location, AnotherUpdateDTO anotherUpdateDTO)
        {
            var getOneLocationByNameFromRepo = _anotherContract.GetOneLocationByName(location);
            if (getOneLocationByNameFromRepo == null)
            {
                return BadRequest(new { error = "No content available" });
            }

            _mapper.Map(anotherUpdateDTO, getOneLocationByNameFromRepo);

            _modelContract.UpdateWhatever(getOneLocationByNameFromRepo);  // not really needed in this implementation

            _modelContract.SaveChanges();

            return NoContent();
        }
    }
}
