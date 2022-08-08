using System;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        [Required]
        public string HolidayName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
