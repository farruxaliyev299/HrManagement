using System.Collections.Generic;

namespace HR_Management.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; }
        public List<EmployeeUser> Employees { get; set; }
    }
}
