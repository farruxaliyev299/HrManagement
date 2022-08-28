using System;

namespace HR_Management.Models
{
    public class SendMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public DateTime createdAt { get; set; }
        public EmployeeUser FromUser { get; set; }
        public EmployeeUser ToUser { get; set; }
    }
}
