using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public bool isDone { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public bool? IsSuccesfull { get; set; }

        public List<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();

        [NotMapped]
        public List<string> EmployeeIds { get; set; }
    }
}
