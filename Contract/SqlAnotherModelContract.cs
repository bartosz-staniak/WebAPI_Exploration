using API_exploration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class SqlAnotherModelContract : IAnotherModelContract
    {
        private readonly AnotherContext _anotherContext;

        public SqlAnotherModelContract(AnotherContext context)
        {
            _anotherContext = context;
        }
        
        public AnotherModel GetOneLocationByName(string location)
        {
            return _anotherContext.AnotherModels.FirstOrDefault(p => p.Location == location);
        }
        
        public IEnumerable<AnotherModel> GetAllLocations()
        {
            return _anotherContext.AnotherModels.ToList();
        }

        public void CreateAnother(AnotherModel another)
        {
            if (another == null)
            {
                throw new ArgumentNullException(nameof(another));
            }
            _anotherContext.AnotherModels.Add(another);
        }

    }
}
