using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.DTOs
{
    public class WhateverReadDTO
    {
        [Key] // totally optional in this migration case
        public int id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [MaxLength(3)]
        public int TemperatureC { get; set; }

        [Required]
        [MaxLength(3)]
        [Range(0, 100)]
        public int RainChance { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
