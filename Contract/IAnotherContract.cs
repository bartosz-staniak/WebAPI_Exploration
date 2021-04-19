using System.Collections.Generic;
using API_exploration.Models;

namespace API_exploration.Contract
{
    public interface IAnotherContract
    {
        IEnumerable<InitialModel> GetAllLocations();
        InitialModel GetOneLocationByName(string location);
    }
}
