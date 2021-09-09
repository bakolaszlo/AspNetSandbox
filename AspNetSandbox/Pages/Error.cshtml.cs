// <copyright file="Error.cshtml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox.Pages
{
    /// <summary>Error Model Class.</summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
#pragma warning disable SA1649 // File name should match first type name
    public class ErrorModel : PageModel
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>Gets or sets the request identifier.</summary>
        /// <value>The request identifier.</value>
        public string RequestId { get; set; }

        /// <summary>Gets a value indicating whether [show request identifier].</summary>
        /// <value>
        ///   <c>true</c> if [show request identifier]; otherwise, <c>false</c>.</value>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

#pragma warning disable SA1201 // Elements should appear in the correct order
        private readonly ILogger<ErrorModel> logger;
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>Initializes a new instance of the <see cref="ErrorModel" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            this.logger = logger;
        }

        /// <summary>Called when [get].</summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
