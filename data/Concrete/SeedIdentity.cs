using System.Linq;
using System.Threading.Tasks;
using entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace webui.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager,RoleManager<Role> roleManager,IConfiguration configuration)
        {
            var roles = configuration.GetSection("Data:Roles").GetChildren().Select(l => l.Value).ToArray();
            foreach (var item in roles)
            {
                if(!await roleManager.RoleExistsAsync(item)){
                    await roleManager.CreateAsync(new Role{
                        Name = item
                    });
                }
            }

            var role = configuration["Data:AdminUser1:role"];
            var email = configuration["Data:AdminUser1:email"];
            var username = configuration["Data:AdminUser1:username"];
            var password = configuration["Data:AdminUser1:password"];
            var name = configuration["Data:AdminUser1:name"];
            var lastName = configuration["Data:AdminUser1:lastName"];
            var imageUrl = configuration["Data:AdminUser1:imageUrl"];
            var gender = configuration["Data:AdminUser1:gender"];

            if(await userManager.FindByNameAsync(username) == null){
                var user = new User(){
                    Name =name,
                    LastName=lastName,
                    Email=email,
                    EmailConfirmed=true,
                    UserName=username,
                    UniversityId = 1,
                    DepartmentId = 1,
                    Gender = gender,
                    ImageUrl = imageUrl,
                    Point= 100
                };
                var result = await userManager.CreateAsync(user,password);
                if(result.Succeeded){
                    await userManager.AddToRoleAsync(user,role);
                }
            }

            role = configuration["Data:AdminUser2:role"];
            email = configuration["Data:AdminUser2:email"];
            username = configuration["Data:AdminUser2:username"];
            password = configuration["Data:AdminUser2:password"];
            name = configuration["Data:AdminUser2:name"];
            lastName = configuration["Data:AdminUser2:lastName"];
            imageUrl = configuration["Data:AdminUser2:imageUrl"];
            gender = configuration["Data:AdminUser2:gender"];
            
            if(await userManager.FindByNameAsync(username) == null){
                var user = new User(){
                    Name =name,
                    LastName=lastName,
                    Email=email,
                    EmailConfirmed=true,
                    UserName=username,
                    UniversityId = 1,
                    DepartmentId = 1,
                    Gender = gender,
                    ImageUrl = imageUrl,
                    Point= 100
                };
                var result = await userManager.CreateAsync(user,password);
                if(result.Succeeded){
                    await userManager.AddToRoleAsync(user,role);
                }
            }
        }
    }
}