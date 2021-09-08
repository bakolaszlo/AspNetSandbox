﻿// <copyright file="CityControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Tests
{
    using System;
    using System.IO;
    using AspNetSandbox.Controllers;
    using Xunit;

    /// <summary>Test units for CityController.</summary>
    public class CityControllerTests
    {
        /// <summary>CityController Test for London as city.</summary>
        [Fact]
        public void CityControllerTestLondon()
        {
            // Assume
            string content = LoadJsonFromResource("LondonApiResponse");
            var controller = new CityCoordController();

            // Act
            var output = controller.ConvertCityNameResponseToCityObject(content);

            // Assert
            Assert.Equal("London", output.cityName);
            Assert.Equal(-0.1257f, output.longtitude);
            Assert.Equal(51.5085f, output.latitude);
        }

        /// <summary>CityController Test for Brasov as city.</summary>
        [Fact]
        public void CityControllerTestBrasov()
        {
            // Assume
            string content = LoadJsonFromResource("BrasovApiResponse");
            var controller = new CityCoordController();

            // Act
            var output = controller.ConvertCityNameResponseToCityObject(content);

            // Assert
            Assert.Equal("Brasov", output.cityName);
            Assert.Equal(25.3333f, output.longtitude);
            Assert.Equal(45.75f, output.latitude);
        }

        /// <summary>CityController Test for Berlin as city.</summary>
        [Fact]
        public void CityControllerTestBerlin()
        {
            // Assume
            string content = LoadJsonFromResource("BerlinApiResponse");
            var controller = new CityCoordController();

            // Act
            var output = controller.ConvertCityNameResponseToCityObject(content);

            // Assert
            Assert.Equal("Berlin", output.cityName);
            Assert.Equal(13.4105f, output.longtitude);
            Assert.Equal(52.5244f, output.latitude);
        }

        private string LoadJsonFromResource(string filename)
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.{filename}.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
