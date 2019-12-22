using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace StarWars.IdentityModels
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //create default user in authentication database
            var context = serviceProvider.GetRequiredService<UsersDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                User user = new User()
                {
                    Email = "admin@admin.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin"
                };
                userManager.CreateAsync(user, "admin");
            }
        }
    }
}
