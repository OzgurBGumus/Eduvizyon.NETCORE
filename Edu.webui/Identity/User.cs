using Microsoft.AspNetCore.Identity;

namespace Edu.webui.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string BirthDate { get; set; }
        public string Description { get; set; }
    }
}