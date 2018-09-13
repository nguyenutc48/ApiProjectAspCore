using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJwtToken.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if(!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "ngvan.nguyen@samsung.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Admin"
                };
                userManager.CreateAsync(user, "Admin@13579");
            }
        }
    }
}
