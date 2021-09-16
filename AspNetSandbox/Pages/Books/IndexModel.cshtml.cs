// <copyright file="IndexModel.cshtml.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Model for main dashboard of books.</summary>
    public class IndexModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;

        /// <summary>Initializes a new instance of the <see cref="IndexModel" /> class.</summary>
        /// <param name="context">The context.</param>
        public IndexModel(AspNetSandbox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        public IList<Book> Book { get; set; }

        /// <summary>Called when [get asynchronous].</summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task OnGetAsync()
        {
            Book = await this.context.Book.ToListAsync();
        }
    }
}
