// <copyright file="WeatherForecastControllerTest.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.IO;
using AspNetSandbox.Controllers;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>Test units for WeatherForecastController.</summary>
    public class WeatherForecastControllerTest
    {
        /// <summary>Tomorrow response convertion into weather forecast, test.</summary>
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];

            Assert.Equal("Clouds", weatherForecastForTomorrow.Summary);
            Assert.Equal(16, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 2), weatherForecastForTomorrow.Date);
        }

        /// <summary>After tomorrow response convertion into weather forecast, test.</summary>
        [Fact]
        public void ConvertResponseToWeatherForecastAfterTomorrowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            var weatherForecastForTomorrow = ((WeatherForecast[])output)[2];

            // Assert
            Assert.Equal("Clear", weatherForecastForTomorrow.Summary);
            Assert.Equal(22, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 4), weatherForecastForTomorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
