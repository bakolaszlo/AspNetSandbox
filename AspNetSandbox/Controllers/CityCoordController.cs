// <copyright file="CityCoordController.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

namespace AspNetSandbox.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    /// <summary>
    /// The controller that allows us to get third party stuff.
    /// </summary>
    [Route("/weatherForecastCityCoordFrom{city}")]
    [ApiController]
    public class CityCoordController : ControllerBase
    {
        /// <summary>Gets the specified city name and coordinates.</summary>
        /// <param name="city">The city name.</param>
        /// <returns>CityCoord object.</returns>
        [HttpGet]
        public CityCoord Get(string city)
        {
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=392f1cbc2531c9951e2e9e5fbfab4609");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertCityNameResponseToCityObject(response.Content);
        }

        /// <summary>Converts the city name response to city object.</summary>
        /// <param name="content">The content.</param>
        /// <returns>CityCoord object.</returns>
        [NonAction]
        public CityCoord ConvertCityNameResponseToCityObject(string content)
        {
                var json = JObject.Parse(content);
                var currentCityCoord = json["coord"];

                return new CityCoord()
                {
                    CityName = json.Value<string>("name"),
                    Latitude = currentCityCoord.Value<float>("lat"),
                    Longtitude = currentCityCoord.Value<float>("lon"),
                };
        }
    }
}