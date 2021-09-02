using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Controllers
{
    [Route("api/weatherForecastCityCoord")]
    [ApiController]
    public class WeatherForecastCityCoordController : ControllerBase
    {
       
        [HttpGet]
        public CityCoord Get()
        {

            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=London&appid=392f1cbc2531c9951e2e9e5fbfab4609");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertCityCoordResponseToWeatherForecast(response.Content);
        }

        public CityCoord ConvertCityCoordResponseToWeatherForecast(string content, string cityName="Brasov")
        {
                
                var json = JObject.Parse(content);

                   
                    JToken currentCityCoord = json["coord"];

                    return new CityCoord() { 
                        cityName = cityName,
                        latitude = currentCityCoord.Value<float>("lat"),
                        longtitude = currentCityCoord.Value<float>("lon"),
                    };
        }

        }
    }