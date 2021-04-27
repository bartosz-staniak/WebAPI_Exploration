using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_exploration.Models;

namespace API_exploration.Contract
{
    public interface IModelContract
    {
        bool SaveChanges();

        IEnumerable<InitialModel> GetWhateverItReturns();
        InitialModel GetOneById(int id);
        void CreateWhatever(InitialModel initialModel);
    }
}
