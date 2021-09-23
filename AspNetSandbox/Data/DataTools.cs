// <copyright file="DataTools.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetSandbox.Data
{
    /// <summary>
    ///   <para>Class made for data seeding.</para>
    /// </summary>
    public static class DataTools
    {
        /// <summary>The custom connection string.</summary>
#pragma warning disable SA1401 // Fields should be private
        public static string CustomConnectionString = null;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>Seeds the data.</summary>
        /// <param name="app">The application.</param>
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
