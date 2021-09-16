// <copyright file="DetailsModel.cshtml.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Shows details about a book.</summary>
    public class DetailsModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;

        /// <summary>Initializes a new instance of the <see cref="DetailsModel" /> class.</summary>
        /// <param name="context">The context.</param>
        public DetailsModel(AspNetSandbox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        public Book Book { get; set; }

        /// <summary>Called when [get asynchronous].</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Action result.</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
