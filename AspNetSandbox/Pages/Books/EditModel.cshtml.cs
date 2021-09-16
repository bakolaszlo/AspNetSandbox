// <copyright file="EditModel.cshtml.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Dtos;
using AspNetSandbox.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Provides the ability to edit book data.</summary>
    public class EditModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="EditModel" /> class.</summary>
        /// <param name="context">The context.</param>
        /// <param name="hubContext">The hub context.</param>
        /// <param name="mapper">The mapper.</param>
        public EditModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.context = context;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        [BindProperty]
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

        /// <summary>Called when [post asynchronous].</summary>
        /// <returns>Action result.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.context.Attach(Book).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
                await hubContext.Clients.All.SendAsync("BookEdited", Book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return this.context.Book.Any(e => e.Id == id);
        }
    }
}
