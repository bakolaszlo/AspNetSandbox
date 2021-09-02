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

            string content = "{\"coord\":{\"lon\":25.3333,\"lat\":45.75},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02n\"}],\"base\":\"stations\",\"main\":{\"temp\":283.9,\"feels_like\":283.02,\"temp_min\":283.59,\"temp_max\":283.9,\"pressure\":1023,\"humidity\":76,\"sea_level\":1023,\"grnd_level\":954},\"visibility\":10000,\"wind\":{\"speed\":4.16,\"deg\":268,\"gust\":10.44},\"clouds\":{\"all\":14},\"dt\":1630611182,\"sys\":{\"type\":2,\"id\":2039162,\"country\":\"RO\",\"sunrise\":1630554065,\"sunset\":1630601763},\"timezone\":10800,\"id\":683843,\"name\":\"Braşov\",\"cod\":200}";
            var controller = new CityCoordController();

            // Act
            var output = controller.ConvertCityNameResponseToCityObject(content,"Brasov");


            // Assert
            Assert.Equal("Brasov", output.cityName); //{"coord":{"lon":25.3333,"lat":45.75}
            Assert.Equal(25.3333f, output.longtitude);
            Assert.Equal(45.75f, output.latitude);

        }


        [Fact]
        public void CityControllerTestLondon()
        {
            //Assume
            string content = "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":290.08,\"feels_like\":289.79,\"temp_min\":288.7,\"temp_max\":291.21,\"pressure\":1026,\"humidity\":75},\"visibility\":10000,\"wind\":{\"speed\":5.66,\"deg\":90},\"clouds\":{\"all\":90},\"dt\":1630612979,\"sys\":{\"type\":1,\"id\":1414,\"country\":\"GB\",\"sunrise\":1630559700,\"sunset\":1630608346},\"timezone\":3600,\"id\":2643743,\"name\":\"London\",\"cod\":200}";
            var controller = new CityCoordController();

            //Act
            var output = controller.ConvertCityNameResponseToCityObject(content,"London");

            //Assert
            Assert.Equal("London", output.cityName);
            Assert.Equal(-0.1257f,output.longtitude); // Postman: "lon": -0.1257, "lat": 51.5085
            Assert.Equal(51.5085f, output.latitude);
        }


        [Fact]
        public void CityControllerTestBerlin()
        {
            //Assume
            string content = "{\"coord\":{\"lon\":13.4105,\"lat\":52.5244},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"base\":\"stations\",\"main\":{\"temp\":288.99,\"feels_like\":288.82,\"temp_min\":286.01,\"temp_max\":290.34,\"pressure\":1015,\"humidity\":84},\"visibility\":10000,\"wind\":{\"speed\":1.34,\"deg\":345,\"gust\":4.47},\"clouds\":{\"all\":0},\"dt\":1630613798,\"sys\":{\"type\":2,\"id\":2011538,\"country\":\"DE\",\"sunrise\":1630556350,\"sunset\":1630605201},\"timezone\":7200,\"id\":2950159,\"name\":\"Berlin\",\"cod\":200}";
            var controller = new CityCoordController();

            //Act
            var output = controller.ConvertCityNameResponseToCityObject(content,"Berlin");

            //Assert

            Assert.Equal("Berlin", output.cityName);
            Assert.Equal(13.4105f,output.longtitude); // Postman "lon":13.4105,"lat":52.5244
            Assert.Equal(52.5244f, output.latitude);
        }
      
    }
}
