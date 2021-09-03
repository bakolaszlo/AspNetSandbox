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
    [Route("/weatherForecastCityCoordFrom{city}")]
    [ApiController]
    public class CityCoordController : ControllerBase
    {
       
        [HttpGet]
        public CityCoord Get(string city)
        {

            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=392f1cbc2531c9951e2e9e5fbfab4609");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return ConvertCityNameResponseToCityObject(response.Content);
        }

        [NonAction]
        public CityCoord ConvertCityNameResponseToCityObject(string content)
        {
                var json = JObject.Parse(content);
                var currentCityCoord = json["coord"];

                return new CityCoord() { 
                    cityName = json.Value<string>("name"),
                    latitude = currentCityCoord.Value<float>("lat"),
                    longtitude = currentCityCoord.Value<float>("lon"),
                };
        }

        }
    }