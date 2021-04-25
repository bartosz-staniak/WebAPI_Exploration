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
        public AnotherController(IAnotherContract anotherContract)
        {
            _anotherContract = anotherContract;
        }

        [HttpGet]
        public IEnumerable<Locations> Get()
        {
            return new Locations;
        }
    }
}
