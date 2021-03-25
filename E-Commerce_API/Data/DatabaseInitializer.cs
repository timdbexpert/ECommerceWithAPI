using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Data
{
    internal class DatabaseInitializer
    {

        internal static void Seed(IServiceScope scoped)
        {
            using (var _context = scoped.ServiceProvider.GetRequiredService<CommerceDbContext>())
            {
           
                var manager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!manager.Users.Any())
                {
                    var configuration = scoped.ServiceProvider.GetRequiredService<IConfiguration>();
                    AppUser user = new AppUser
                    {
                        UserName = configuration["User:username"],
                        Email = configuration["User:email"]

                    };
                    manager.CreateAsync(user, configuration["User:password"]).GetAwaiter().GetResult();

                    var roles = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                    List<IdentityRole<int>> list = new List<IdentityRole<int>>();

                    if (!roles.Roles.Any())
                    {

                        string[] UserRoles = configuration["Roles"].Split(",");
                        foreach (var role in UserRoles)
                        {
                            IdentityRole<int> identityRole = new IdentityRole<int>
                            {
                                Name = role
                            };
                            list.Add(identityRole);
                            roles.CreateAsync(identityRole).GetAwaiter().GetResult();

                        }
                    }
                    manager.AddToRoleAsync(user, list[0].Name).GetAwaiter().GetResult();
                }
            }

        }
    }
}
