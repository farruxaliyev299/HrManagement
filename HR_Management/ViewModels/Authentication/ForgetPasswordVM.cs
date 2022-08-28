using System.ComponentModel.DataAnnotations;

namespace HR_Management.ViewModels.Authentication
{
    public class ForgetPasswordVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
