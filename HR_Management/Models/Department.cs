using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string? DepartmentHead { get; set; }
        public List<EmployeeUser> Employees { get; set; }
        public int? DepartmentCount { get; set; }
    }
}
