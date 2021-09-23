// <copyright file="FileOperationWithBooksTests.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>File operations tests.</summary>
    public class FileOperationWithBooksTests
    {
        /// <summary>Enumerates the file test.</summary>
        [Fact]
        public void EnumerateFileTest()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(".");
            var enumerateFiles = directoryInfo.EnumerateFiles();
            foreach (var file in enumerateFiles)
            {
                Console.WriteLine(file.Name);
            }
        }

        /// <summary>Creates the file test.</summary>
        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("NewSettings.json", @"{
  ""ConnectionStrings"": {
    ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-AspNetSandbox-A4F5A88D-A802-4EE0-827F-5445AE63E418;Trusted_Connection=True;MultipleActiveResultSets=true"",
    ""DefaultConnection"": ""Port=5432;Database=d8l3egg3qlh408; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com;User Id=xgjqcvlyhnqcry;Password=3a7ae7201a45921606c09d249c428d5f1f3e75dfa6330767c29845b0b9adcbfc; SSL Mode=Require;Trust Server Certificate=true;"",
    ""LocalConnection"": ""Port=5432;Database=postgres; Host=localhost;User Id=postgres;Password=OzvJbv4lGjcEC3aSOMS2;"",
    ""Heroku"": ""postgres://xgjqcvlyhnqcry:3a7ae7201a45921606c09d249c428d5f1f3e75dfa6330767c29845b0b9adcbfc@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d8l3egg3qlh408""
  },
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft"": ""Warning"",
      ""Microsoft.Hosting.Lifetime"": ""Information""
    }
  },
  ""AllowedHosts"": ""*""
}
");
        }

        /// <summary>Reads the file test.</summary>
        [Fact]
        public void ReadFileTest()
        {
            using (var fs = File.OpenRead("NewSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var readString = temp.GetString(b);
                    Console.WriteLine(readString);
                }
            }
        }
    }
}
