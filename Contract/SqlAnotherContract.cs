using API_exploration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class SqlAnotherContract : IAnotherContract
    {
        public SqlAnotherContract()
        {

        }

        public IEnumerable<AnotherModel> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public AnotherModel GetOneLocationByName(string location)
        {
            throw new NotImplementedException();
        }
    }
}
