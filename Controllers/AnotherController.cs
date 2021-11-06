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
        private readonly IAnotherModelContract _anotherModelContract;
        private readonly IMapper _mapper;

        public AnotherController(IAnotherModelContract anotherModelContract)
        {
            _anotherModelContract = anotherModelContract;
        }

        //api/another/
        [HttpGet("{location}")]
        public ActionResult<Locations> GetLocationByName(string location)
        {
            var getByLocation = _anotherModelContract.GetOneLocationByName(location);
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
            var anotherLocations = _anotherModelContract.GetAllLocations();
            return Ok(anotherLocations);
        }

        [HttpPut("{location}")] // location name
        public ActionResult PutAnother(string location, AnotherUpdateDTO anotherUpdateDTO)
        {
            var getOneLocationByNameFromRepo = _anotherModelContract.GetOneLocationByName(location);
            if (getOneLocationByNameFromRepo == null)
            {
                return BadRequest(new { error = "No content available" });
            }

            _mapper.Map(anotherUpdateDTO, getOneLocationByNameFromRepo); // null reference exception thrwon

            _anotherModelContract.UpdateAnother(getOneLocationByNameFromRepo);  // not really needed in this implementation

            _anotherModelContract.SaveChanges();

            return NoContent();
        }
    }
}
