using System.ComponentModel.DataAnnotations;

namespace Edu.webui.Models
{
    public class PasswordResetModel
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string token { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Compare(nameof(password))]
        [DataType(DataType.Password)]
        public string rePassword { get; set; }
    }
}