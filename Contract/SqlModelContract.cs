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
            
        }

        public IEnumerable<InitialModel> GetWhateverItReturns()
        {
            return _context.InitialModels.ToList();
        }
    }
}
