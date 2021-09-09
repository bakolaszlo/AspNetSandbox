// <copyright file="Privacy.cshtml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
    /// <summary>Privacy Model class.</summary>
#pragma warning disable SA1649 // File name should match first type name
    public class PrivacyModel : PageModel
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly ILogger<PrivacyModel> logger;

        /// <summary>Initializes a new instance of the <see cref="PrivacyModel" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            this.logger = logger;
        }

        /// <summary>Called when [get].</summary>
        public void OnGet()
        {
        }
    }
}
