using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models
{
    public class EmployeeUser: IdentityUser
    {
        [Required, MaxLength(30)]
        public string FullName { get; set; }

        [Required , DataType (DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType (DataType.ImageUrl)]
        public string ProfilePhoto { get; set; }

        [Required , MaxLength(9)]
        public string IdSerialNo { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required , MaxLength(7)]
        public string FIN { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? QuitDate { get; set; }
        public bool IsQuitted { get; set; }
        public bool IsHead { get; set; }

        public string ConnectionId { get; set; }
        public DateTime? DisconnectedAt { get; set; }

        public List<ProjectEmployee> ProjectEmployees { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
