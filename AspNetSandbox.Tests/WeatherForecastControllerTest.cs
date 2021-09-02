using AspNetSandbox.Controllers;
using System;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class WeatherForecastControllerTest
    {
       

        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = "{\"lat\":46.652,\"lon\":24.485,\"timezone\":\"Europe/Bucharest\",\"timezone_offset\":10800,\"current\":{\"dt\":1630565282,\"sunrise\":1630554201,\"sunset\":1630602035,\"temp\":286.61,\"feels_like\":286.1,\"pressure\":1020,\"humidity\":80,\"dew_point\":283.23,\"uvi\":1.94,\"clouds\":100,\"visibility\":10000,\"wind_speed\":6.12,\"wind_deg\":306,\"wind_gust\":8.09,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}]},\"daily\":[{\"dt\":1630576800,\"sunrise\":1630554201,\"sunset\":1630602035,\"moonrise\":1630534320,\"moonset\":1630594260,\"moon_phase\":0.84,\"temp\":{\"day\":289.35,\"min\":283.38,\"max\":291.91,\"night\":283.38,\"eve\":289.68,\"morn\":284.89},\"feels_like\":{\"day\":288.62,\"night\":282.47,\"eve\":288.77,\"morn\":284.44},\"pressure\":1020,\"humidity\":61,\"dew_point\":281.83,\"wind_speed\":8.96,\"wind_deg\":314,\"wind_gust\":11.16,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":100,\"pop\":0.15,\"uvi\":5.39},{\"dt\":1630663200,\"sunrise\":1630640678,\"sunset\":1630688319,\"moonrise\":1630624020,\"moonset\":1630683240,\"moon_phase\":0.88,\"temp\":{\"day\":291.68,\"min\":280.09,\"max\":294.04,\"night\":285.44,\"eve\":291.18,\"morn\":280.09},\"feels_like\":{\"day\":290.87,\"night\":284.63,\"eve\":290.5,\"morn\":280.09},\"pressure\":1021,\"humidity\":49,\"dew_point\":280.88,\"wind_speed\":4.61,\"wind_deg\":329,\"wind_gust\":5.28,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":3,\"pop\":0,\"uvi\":5.53},{\"dt\":1630749600,\"sunrise\":1630727154,\"sunset\":1630774602,\"moonrise\":1630714320,\"moonset\":1630771800,\"moon_phase\":0.91,\"temp\":{\"day\":294.73,\"min\":282.14,\"max\":296.26,\"night\":289.58,\"eve\":293.39,\"morn\":282.14},\"feels_like\":{\"day\":294.12,\"night\":288.77,\"eve\":292.8,\"morn\":282.14},\"pressure\":1017,\"humidity\":45,\"dew_point\":282.45,\"wind_speed\":2.62,\"wind_deg\":320,\"wind_gust\":3.82,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":0,\"pop\":0,\"uvi\":5.41},{\"dt\":1630836000,\"sunrise\":1630813631,\"sunset\":1630860885,\"moonrise\":1630804920,\"moonset\":1630860000,\"moon_phase\":0.94,\"temp\":{\"day\":291.84,\"min\":286.09,\"max\":295.31,\"night\":289.49,\"eve\":295.31,\"morn\":286.09},\"feels_like\":{\"day\":291.28,\"night\":288.69,\"eve\":294.65,\"morn\":285.35},\"pressure\":1020,\"humidity\":58,\"dew_point\":283.38,\"wind_speed\":3.87,\"wind_deg\":110,\"wind_gust\":8.27,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":100,\"pop\":0.08,\"uvi\":3.7},{\"dt\":1630922400,\"sunrise\":1630900107,\"sunset\":1630947168,\"moonrise\":1630895820,\"moonset\":1630947900,\"moon_phase\":0.98,\"temp\":{\"day\":290.8,\"min\":285.17,\"max\":293.04,\"night\":289.6,\"eve\":293.04,\"morn\":285.26},\"feels_like\":{\"day\":289.8,\"night\":288.68,\"eve\":292.26,\"morn\":284.09},\"pressure\":1024,\"humidity\":45,\"dew_point\":278.65,\"wind_speed\":4.9,\"wind_deg\":148,\"wind_gust\":6.62,\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":80,\"pop\":0,\"uvi\":2.58},{\"dt\":1631008800,\"sunrise\":1630986584,\"sunset\":1631033450,\"moonrise\":1630986720,\"moonset\":1631035680,\"moon_phase\":0,\"temp\":{\"day\":293.03,\"min\":284.52,\"max\":296.11,\"night\":289.03,\"eve\":295.5,\"morn\":284.52},\"feels_like\":{\"day\":292.17,\"night\":287.9,\"eve\":294.63,\"morn\":283.44},\"pressure\":1024,\"humidity\":42,\"dew_point\":279.69,\"wind_speed\":3.05,\"wind_deg\":177,\"wind_gust\":4.06,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":4,\"pop\":0,\"uvi\":3},{\"dt\":1631095200,\"sunrise\":1631073060,\"sunset\":1631119731,\"moonrise\":1631077680,\"moonset\":1631123340,\"moon_phase\":0.05,\"temp\":{\"day\":292.91,\"min\":283.48,\"max\":295.18,\"night\":290.47,\"eve\":295.18,\"morn\":283.48},\"feels_like\":{\"day\":292.04,\"night\":289.48,\"eve\":294.38,\"morn\":282.34},\"pressure\":1019,\"humidity\":42,\"dew_point\":279.67,\"wind_speed\":2.53,\"wind_deg\":169,\"wind_gust\":3.07,\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":100,\"pop\":0,\"uvi\":3},{\"dt\":1631181600,\"sunrise\":1631159536,\"sunset\":1631206012,\"moonrise\":1631168700,\"moonset\":1631211060,\"moon_phase\":0.08,\"temp\":{\"day\":295.71,\"min\":285.16,\"max\":296.38,\"night\":289.7,\"eve\":294.37,\"morn\":285.16},\"feels_like\":{\"day\":294.88,\"night\":288.95,\"eve\":293.62,\"morn\":284.01},\"pressure\":1015,\"humidity\":33,\"dew_point\":278.59,\"wind_speed\":4.19,\"wind_deg\":160,\"wind_gust\":5.29,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":49,\"pop\":0.3,\"rain\":0.18,\"uvi\":3}]}";
            WeatherForecastController controller = new WeatherForecastController();


            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);



            // Assert
            Assert.Equal("Clouds", ((WeatherForecast[])output)[0].Summary);
            Assert.Equal(16,((WeatherForecast[])output)[0].TemperatureC);
        }
    }
}
