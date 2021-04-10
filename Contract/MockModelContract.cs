using API_exploration.Models;
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
            throw new NotImplementedException();
        }

        public IEnumerable<InitialModel> GetWhateverItReturns()
        {
            throw new NotImplementedException();
        }
    }
}
