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
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        [Required]
        public int RainChance { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
