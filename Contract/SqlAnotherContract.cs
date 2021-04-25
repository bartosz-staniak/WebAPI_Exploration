using API_exploration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class SqlAnotherContract : IAnotherContract
    {
        private readonly AnotherContext _context;

        public SqlAnotherContract(AnotherContext context)
        {
            _context = context;
        }
        
        public AnotherModel GetOneLocationByName(string location)
        {
            return _context.AnotherModels.FirstOrDefault(p => p.Location == location);
        }
        
        public IEnumerable<AnotherModel> GetAllLocations()
        {
            return _context.AnotherModels.ToList();
        }

    }
}
