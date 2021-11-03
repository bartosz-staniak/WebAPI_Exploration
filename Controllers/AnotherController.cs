using API_exploration.Contract;
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
        private readonly IAnotherContract _anotherContract;

        public AnotherController(IAnotherContract anotherContract)
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

        [HttpPut("{id}")]
        public ActionResult PutWhatever(int id, AnotherUpdateDTO anotherUpdateDTO)
        {
            var getOneByIdFromRepo = _anotherContract.GetOneById(id);
            if (getOneByIdFromRepo == null)
            {
                return BadRequest(new { error = "No content available" });
            }

            if (anotherUpdateDTO.TemperatureC > 60)
            {
                return BadRequest(new { error = "The temperature cannot be higher than 60" });
            }

            _mapper.Map(anotherUpdateDTO, getOneByIdFromRepo);

            _modelContract.UpdateWhatever(getOneByIdFromRepo);  // not really needed in this implementation

            _modelContract.SaveChanges();

            return NoContent();
        }
    }
}
