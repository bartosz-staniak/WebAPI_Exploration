using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class WhateverContext : DbContext

    {
        public WhateverContext(DbContextOptions<WhateverContext> options) : base (options)
        {

        }

        public DbSet<InitialModel> InitialModels { get; set; }
    }
}
