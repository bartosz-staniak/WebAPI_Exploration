using System.ComponentModel.DataAnnotations;

namespace API_exploration.Models
{
    public class AnotherModel
    {
        [Key]
        public string Location { get; set; }

        [Required]
        public string Location_Size { get; set; }
        [Required]
        public string Population { get; set; }

        public string SubmittedBy { get; set; }
    }
}
