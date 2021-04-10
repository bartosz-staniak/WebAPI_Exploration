﻿using API_exploration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class MockModelContract : IModelContract
    {
        public InitialModel GetOneById(int id)
        {
            return new InitialModel { id = 0, Date = DateTime.Now, Location = "Tokio", RainChance = 90, Summary = "Stormy", TemperatureC = 30 };
        }

        public IEnumerable<InitialModel> GetWhateverItReturns()
        {
            throw new NotImplementedException();
        }
    }
}
