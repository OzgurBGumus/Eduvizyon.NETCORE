using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Edu.webui.Models
{
    public class UserDetailsModel
    {
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        [Required]
        public string BirthDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
    }
}