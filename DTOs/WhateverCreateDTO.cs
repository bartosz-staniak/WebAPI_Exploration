using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.DTOs
{
    public class WhateverCreateDTO
    {
        public int id { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Location { get; set; }

        public int TemperatureC { get; set; }

        public int RainChance { get; set; }

        public string Summary { get; set; }

        public string SubmittedBy { get; set; } // don't want to expose this field to API users
    }
}
