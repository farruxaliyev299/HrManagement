using HR_Management.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.ViewModels
{
    public class CreateEmployeeUserVM
    {
        [Required , MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required , DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ProfilePhoto { get; set; }

        [Required, MaxLength(9)]
        public string SerialNo { get; set; }

        [Required , DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required, MaxLength(7)]
        public string FIN { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public bool IsHead { get; set; }

        [NotMapped , Required]
        public IFormFile Photo { get; set; }
    }
}
