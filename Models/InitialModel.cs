﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.Models
{
    public class InitialModel
    {
        [Key] // totally optional in this migration case
        public int id { get; set; }
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int TemperatureC { get; set; }

        public int RainChance { get; set; }

        public string Summary { get; set; }
    }
}
