// <copyright file="Index.cshtml.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox.Pages
{
    /// <summary>Index Page class.</summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        /// <summary>Initializes a new instance of the <see cref="IndexModel" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;
        }

        /// <summary>Called when [get].</summary>
        public void OnGet()
        {
        }
    }
}
