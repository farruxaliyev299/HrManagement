using HR_Management.Models;
using System.Collections.Generic;

namespace HR_Management.ViewModels
{
    public class WarningVM
    {
        public List<Warning> Warnings { get; set; }
        public List<EmployeeUser> Employees { get; set; }
    }
}
