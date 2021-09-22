// <copyright file="StartupTests.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    ///   <para>Test unit for startup.</para>
    /// </summary>
    public class StartupTests
    {
        /// <summary>Checks the conversion ie connection string.</summary>
        [Fact]
        public void CheckConversionIEConnectionString()
        {
            // Assume
            string databaseURL = @"postgres://xgjqcvlyhnqcry:3a7ae7201a45921606c09d249c428d5f1f3e75dfa6330767c29845b0b9adcbfc@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d8l3egg3qlh408";

            // Act
            string converted = Startup.ConvertConnectionString(databaseURL);
            string expected = @"Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com;Port=5432;Username=xgjqcvlyhnqcry;Password=3a7ae7201a45921606c09d249c428d5f1f3e75dfa6330767c29845b0b9adcbfc;Database=d8l3egg3qlh408;SSL Mode=Require;Trust Server Certificate=True";

            // Assert
            Assert.Equal(expected, converted);
        }
    }
}
