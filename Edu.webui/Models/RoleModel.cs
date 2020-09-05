using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Edu.webui.Identity;
using Microsoft.AspNetCore.Identity;

namespace Edu.webui.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }
    public class RoleDetailModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToDelete { get; set; }
        public string[] IdsToAdd { get; set; }
    }
}