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
        [DataType(DataType.Date)] // take down and renew migration for it to work
        public DateTime Date { get; set; } // date is always set to 0001-01-01T00:00:00

        [Required] // field can be empty when just "" are sent
        public string Location { get; set; }

        [Required]
        [MaxLength(3)] // field can store values with more than 3 digits
        public int TemperatureC { get; set; }

        [Required]
        [MaxLength(3)] // field can store values with more than 3 digits
        [Range(0,100)] // this validation attempt does not work
        public int RainChance { get; set; }

        [Required] // field can be empty when just "" are sent
        public string Summary { get; set; }

        [Required] // field can be empty when just "" are sent
        public string SubmittedBy { get; set; }
    }
}
