namespace HR_Management.Models
{
    public class ProjectEmployee
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string EmployeeId { get; set; }
        public EmployeeUser Employee { get; set; }
    }
}
