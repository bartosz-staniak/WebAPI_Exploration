using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_exploration.Models;

namespace API_exploration.Contract
{
    public class IModelContract
    {
        IEnumerable<InitialModel> GetWhateverItReturns();
    }
}
