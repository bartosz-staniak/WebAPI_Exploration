﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.DTOs
{
    public class AnotherCreateDTO
    {
        // public int id { get; set; } // the database will take care of assigning an id

        [Required] // these Data Annotations make the response return a 400 Bad request code instead of a 500 server error code
        public DateTime DateAndTime { get; set; }

        [Required]
        public string Location { get; set; }

        public int TemperatureC { get; set; }

        [Range(0, 90)] // range validation works in this Create DTO context; it's also doubled in the controller
        public int RainChance { get; set; }

        [Required]
        [MaxLength(20)]
        public string Summary { get; set; }

        [Required]
        public string SubmittedBy { get; set; }
    }
}
