using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.DTOs
{
    public class WhateverCreateDTO
    {
        // public int id { get; set; } // the database will take care of assigning an id

        [Required]
        public DateTime DateAndTime { get; set; }

        public string Location { get; set; }

        public int TemperatureC { get; set; }

        public int RainChance { get; set; }

        public string Summary { get; set; }

        [Required]
        public string SubmittedBy { get; set; }
    }
}
