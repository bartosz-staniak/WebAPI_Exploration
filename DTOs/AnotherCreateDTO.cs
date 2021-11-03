using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_exploration.DTOs
{
    public class AnotherCreateDTO
    {
        // public int id { get; set; } // the database will take care of assigning an id

        [Required]
        public string Location { get; set; } // as per the comment above these two lines could be redundant

        [Required]
        public string Location_Size { get; set; }

        [Required]
        public string Population { get; set; }

        [Required]
        public string SubmittedBy { get; set; }
    }
}
