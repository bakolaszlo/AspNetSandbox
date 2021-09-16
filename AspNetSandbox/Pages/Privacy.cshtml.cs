// <copyright file="Privacy.cshtml.cs" company="P33">
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
    /// <summary>Privacy page model class.</summary>
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyModel"/> class.
        /// </summary>
        /// <param name="logger"> Logger. </param>
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
