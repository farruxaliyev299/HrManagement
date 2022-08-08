using System;

namespace HR_Management.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventLocation { get; set; }
    }
}
