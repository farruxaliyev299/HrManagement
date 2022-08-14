using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models
{
    public class Warning
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime WarningDate { get; set; }

        public string EmployeeId { get; set; }

        [NotMapped]
        public EmployeeUser Employee { get; set; }
    }
}
