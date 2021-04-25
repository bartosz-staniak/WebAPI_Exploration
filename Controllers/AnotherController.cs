﻿using API_exploration.Contract;
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

        [HttpGet]
        public AnotherController(IAnotherContract anotherContract)
        {
            _anotherContract = anotherContract;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Locations>> Get()
        {
            var anotherLocations = _anotherContract.GetAllLocations();
            return Ok(anotherLocations);
        }
    }
}
