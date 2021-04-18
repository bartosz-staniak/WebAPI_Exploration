using System;
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
        [MaxLength(3)]
        public int TemperatureC { get; set; }

        [Required]
        [MaxLength(3)]
        [Range(0,100)]
        public int RainChance { get; set; }

        [Required]
        public string Summary { get; set; }
    }

    public class AnotherModel
    {
        [Key]
        public string Location { get; set; }

        [Required]
        public string Location_Size { get; set; }
        [Required]
        public string Population { get; set; }
    }
}
