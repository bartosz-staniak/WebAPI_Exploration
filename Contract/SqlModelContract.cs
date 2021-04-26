using API_exploration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class SqlModelContract : IModelContract
    {
        private readonly WhateverContext _context;

        public SqlModelContract(WhateverContext context)
        {
            _context = context;
        }

        public InitialModel GetOneById(int id)
        {
            return _context.InitialModels.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<InitialModel> GetWhateverItReturns()
        {
            return _context.InitialModels.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        
        public void CreateWhatever(WhateverContext whatever)
        {
            if (whatever == null)
            {

            }
            throw new NotImplementedException();
        }
    }
}
