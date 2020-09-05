using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Edu.webui.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var firstname = configuration["Data:AdminUser:username"];
            var lastname = configuration["Data:AdminUser:lastname"];
            var email = configuration["Data:AdminUser:email"];
            var phonenumber = configuration["Data:AdminUser:phonenumber"];
            var role = configuration["Data:AdminUser:role"];
            var password = configuration["Data:AdminUser:password"];
            if(await userManager.FindByNameAsync(username) == null)
            {
                System.Console.WriteLine("SeedIdentity Is Started.");
                await roleManager.CreateAsync(new IdentityRole(role));
                var user = new User(){
                    UserName=username,
                    FirstName=firstname,
                    LastName=lastname,
                    Email=email,
                    PhoneNumber=phonenumber,
                    EmailConfirmed=true,
                    ImageUrl="1.png"
                };
                var result = await userManager.CreateAsync(user,password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                    System.Console.WriteLine("SeedIdentity Admin User Created");
                    System.Console.WriteLine("SeedIdentity Ended.");
                }
                else{
                    System.Console.WriteLine("There was some problems at SeedIdentity:");
                    foreach (var error in result.Errors)
                    {
                        System.Console.WriteLine(error.Description);
                    }
                }
                
            }
        }
    }
}