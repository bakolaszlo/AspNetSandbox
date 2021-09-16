// <copyright file="DeleteModel.cshtml.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

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
    /// <summary>Deletes books.</summary>
    public class DeleteModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="DeleteModel" /> class.</summary>
        /// <param name="context">The context.</param>
        /// <param name="hubContext">The hub context.</param>
        /// <param name="mapper">The mapper.</param>
        public DeleteModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext, IMapper mapper)
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
        /// <param name="id">The identifier.</param>
        /// <returns>Action result.</returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FindAsync(id);

            if (Book != null)
            {
                this.context.Book.Remove(Book);
                await this.context.SaveChangesAsync();
                await hubContext.Clients.All.SendAsync("BookRemoved", Book);
            }

            return RedirectToPage("./Index");
        }
    }
}
