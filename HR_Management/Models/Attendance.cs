using System;

namespace HR_Management.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string EmployeeId { get; set; }
        public EmployeeUser Employee { get; set; }
        public bool AttendanceStatus { get; set; }
    }
}
