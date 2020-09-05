using System.ComponentModel.DataAnnotations;

namespace Edu.webui.Models
{
    public class PasswordChange
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        [Required]
        public string oldPassword { get; set; }
        [Required]
        public string newPassword { get; set; }
        [Required]
        [Compare(nameof(newPassword))]
        public string reNewPassword { get; set; }
    }
}