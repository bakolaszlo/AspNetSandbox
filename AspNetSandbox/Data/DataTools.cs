 using AspNetSandbox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Data
{
    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The books are there");
                }
                else
                {
                    applicationDbContext.Add(new Book
                    {
                        Title = "Az isteni formula",
                        Language = "Hungarian",
                        Author = "José Rodrigues dos Santos",
                    });
                    applicationDbContext.Add(new Book
                    {
                        Title = "The Big Bang",
                        Language = "Hungarian",
                        Author = "I dunno",
                    });
                    applicationDbContext.SaveChanges();
                    Console.WriteLine(applicationDbContext.Book.ToList()[0].Title);
                }
            }
        }
    }
}
