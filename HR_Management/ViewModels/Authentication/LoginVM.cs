using System.ComponentModel.DataAnnotations;

namespace HR_Management.ViewModels.Authentication
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isPersistent { get; set; }
    }
}
