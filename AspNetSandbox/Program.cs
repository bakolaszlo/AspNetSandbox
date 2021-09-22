// <copyright file="Program.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Data;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox
{
    /// <summary>
    ///   <para>Main Program.</para>
    /// </summary>
    public class Program
    {

        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>The program exit code.</returns>
        public static int Main(string[] args)
        {
            var argsResult = Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }

                       if (o.ConnectionString != null)
                       {
                           Console.WriteLine($"Custom connection string set to: {o.ConnectionString}");
                           DataTools.CustomConnectionString = o.ConnectionString;
                       }
                       else
                       {
                           Console.WriteLine("Using the default connection string");
                       }

                   });
            if (argsResult.Tag == ParserResultType.NotParsed)
            {
                return 1;
            }

            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        /// <summary>Creates the host builder.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        ///   <para>Class from CommandLineParser</para>
        ///   <para>
        ///     <font color="#333333">Makes the cmd verbose.</font>
        ///   </para>
        /// </summary>

        public class Options
        {
            /// <summary>Gets or sets a value indicating whether this <see cref="Options" /> is verbose.</summary>
            /// <value>
            ///   <c>true</c> if verbose; otherwise, <c>false</c>.</value>
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option('c', "connection-string", Required = false, HelpText = "Set's custom connection string to connect to.")]
            public string ConnectionString { get; set; }
        }
    }
}
