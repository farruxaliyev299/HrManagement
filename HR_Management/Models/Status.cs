using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public List<EmployeeUser> Employees { get; set; }
    }
}
