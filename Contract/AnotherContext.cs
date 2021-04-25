﻿using API_exploration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Contract
{
    public class AnotherContext : DbContext
    {
        public AnotherContext(DbContextOptions<AnotherContext> options) : base(options)
        {

        }

        public DbSet<AnotherModel> AnotherModels { get; set; }
    }
}
