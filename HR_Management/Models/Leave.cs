using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models
{
    public class Leave
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Reason { get; set; }

        public bool? isAccepted { get; set; }

        public string EmployeeId { get; set; }

        [NotMapped]
        public EmployeeUser Employee { get; set; }
    }
}
