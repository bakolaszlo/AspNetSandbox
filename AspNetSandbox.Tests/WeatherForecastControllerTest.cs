using AspNetSandbox.Controllers;
using System;
using System.IO;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class WeatherForecastControllerTest
    {
        

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

            /*
            var forecastArray = (WeatherForecast[])output;

            for (int i = 0; i < forecastArray.Length; i++)
            {
                var weatherForecastTest = forecastArray[i];
                Assert.Equal("Clouds", weatherForecastTest.Summary);
                Assert.Equal(16, weatherForecastTest.TemperatureC);
                Assert.Equal(new DateTime(2021, 9, 2), weatherForecastTest.Date);

            }*/
            
            Assert.Equal("Clouds", weatherForecastForTomorrow.Summary);
            Assert.Equal(16, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021,9,2), weatherForecastForTomorrow.Date);

        }

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
