// <copyright file="ApplicationDbContext.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">DbContextOptions.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the book in db.
        /// </summary>
        public DbSet<AspNetSandbox.Models.Book> Book { get; set; }
    }
}
