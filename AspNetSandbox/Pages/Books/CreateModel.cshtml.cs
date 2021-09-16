// <copyright file="CreateModel.cshtml.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using AspNetSandbox.Dtos;
using AspNetSandbox.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Creates new books to add to our data.</summary>
    public class CreateModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="CreateModel" /> class.</summary>
        /// <param name="context">The context.</param>
        /// <param name="hubContext">The hub context.</param>
        /// <param name="mapper">The mapper.</param>
        public CreateModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.context = context;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        /// <summary>Gets or sets the book dto.</summary>
        /// <value>The book dto.</value>
        [BindProperty]
        public CreateBookDto BookDto { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /// <summary>Called when [post asynchronous].</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Book book = mapper.Map<Book>(BookDto);
            this.context.Book.Add(book);
            await this.context.SaveChangesAsync();
            await hubContext.Clients.All.SendAsync("BookCreated", book);

            return RedirectToPage("./Index");
        }
    }
}
