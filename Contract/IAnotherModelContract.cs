using System.Collections.Generic;
using API_exploration.Models;

namespace API_exploration.Contract
{
    public interface IAnotherModelContract
    {
        IEnumerable<AnotherModel> GetAllLocations();
        AnotherModel GetOneLocationByName(string location);
    }
}
