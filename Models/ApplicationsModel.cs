using System.ComponentModel.DataAnnotations;

namespace API_exploration.Models
{
    public class ApplicationsModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public int SalaryExpectations { get; set; }

        public string Remarks { get; set; }

        public string SubmittedBy { get; set; }
    }
}