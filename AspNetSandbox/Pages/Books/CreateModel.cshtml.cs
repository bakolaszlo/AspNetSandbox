﻿using System.Threading.Tasks;
using AspNetSandbox.Models;
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
        public CreateModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.context.Book.Add(Book);
            hubContext.Clients.All.SendAsync("BookCreated", Book);
            await this.context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
