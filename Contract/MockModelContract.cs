using API_exploration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class MockModelContract : IModelContract
    {
        public IEnumerable<InitialModel> GetWhateverItReturns()
        {
            var whatever = new List<InitialModel>
            {
                new InitialModel { id = 0, Date = DateTime.Now, Location = "Tokio", RainChance = 90, Summary = "Stormy", TemperatureC = 30 },
                new InitialModel { id = 1, Date = DateTime.Now, Location = "Osaka", RainChance = 50, Summary = "Windy", TemperatureC = 25 }
            };
            return whatever;
        }

        public InitialModel GetOneById(int id)
        {
            return new InitialModel { id = 0, Date = DateTime.Now, Location = "Tokio", RainChance = 90, Summary = "Stormy", TemperatureC = 30 };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateWhatever(InitialModel initialModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateWhatever(InitialModel initialModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteWhatever(InitialModel initialModel)
        {
            throw new NotImplementedException();
        }
    }
}
