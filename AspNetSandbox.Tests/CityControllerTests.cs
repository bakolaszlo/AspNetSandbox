using AspNetSandbox.Controllers;
using System;
using System.IO;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class CityControllerTests
    {


        [Fact]
        public void CityControllerTestBrasov()
        {
            // Assume

            string content = LoadJsonFromResource("BrasovApiResponse");
            var controller = new CityCoordController();

            // Act
            var output = controller.ConvertCityNameResponseToCityObject(content);



            // Assert
            Assert.Equal("Brașov", output.cityName); //{"coord":{"lon":25.3333,"lat":45.75}
            Assert.Equal(25.3333f, output.longtitude);
            Assert.Equal(45.75f, output.latitude);

        }


        [Fact]
        public void CityControllerTestLondon()
        {
            //Assume
            string content = LoadJsonFromResource("LondonApiResponse");
            var controller = new CityCoordController();

            //Act
            var output = controller.ConvertCityNameResponseToCityObject(content);

            //Assert
            Assert.Equal("London", output.cityName);
            Assert.Equal(-0.1257f,output.longtitude); // Postman: "lon": -0.1257, "lat": 51.5085
            Assert.Equal(51.5085f, output.latitude);
        }


        [Fact]
        public void CityControllerTestBerlin()
        {
            //Assume
            string content = LoadJsonFromResource("BerlinApiResponse");
            var controller = new CityCoordController();

            //Act
            var output = controller.ConvertCityNameResponseToCityObject(content);

            //Assert

            Assert.Equal("Berlin", output.cityName);
            Assert.Equal(13.4105f,output.longtitude); // Postman "lon":13.4105,"lat":52.5244
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
