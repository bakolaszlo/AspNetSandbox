using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVIN_CONST = 273.15f;
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=46.652010&lon=24.484990&exclude=hourly,minutely&appid=392f1cbc2531c9951e2e9e5fbfab4609");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content);
        }

        [NonAction]

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int amount = 5)
        {
            var json = JObject.Parse(content);

            return Enumerable.Range(1, amount).Select(index =>
            {
                JToken jsonDailyForecast = json["daily"][index - 1];
                var unixDateTime = jsonDailyForecast.Value<long>("dt");
                var weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");

                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(jsonDailyForecast),
                    Summary = weatherSummary
                };
            })
            .ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyForecast)
        {
            return (int)Math.Round((jsonDailyForecast["temp"].Value<float>("day") - KELVIN_CONST));
        }


        
    }

    
}
