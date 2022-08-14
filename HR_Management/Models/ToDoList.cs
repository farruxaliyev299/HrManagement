using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(30)]
        public string Description { get; set; }

        public string EmployeeId { get; set; }

        [NotMapped]
        public EmployeeUser Employee { get; set; }
    }
}
