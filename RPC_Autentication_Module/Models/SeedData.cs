using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPC_Autentication_Module.Data;
using System;
using System.Linq;

namespace RPC_Autentication_Module.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RPC_Autentication_ModuleContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RPC_Autentication_ModuleContext>>()))
            {
                // Look for any Users.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Username = "Admin",
                        Password = "Admin",
                        Firstname = "Admin",
                        Lastname = "Admin",
                        BirthDate = DateTime.Parse("1989-2-12")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}