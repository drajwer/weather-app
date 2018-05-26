using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Options
{
    public class OpenWeatherClientOptions
    {
        public string Host { get; set; }
        public string WeatherPath { get; set; }
        public string ApiKey { get; set; }
        public List<string> CityIds { get; set; }

        public string CitiesUrl => $"{Host.TrimEnd('/')}/{WeatherPath.TrimStart('/')}?id={CityIds.Aggregate("", (s,c) => $"{s},{c}").Trim(',')}&units=metric&appid={ApiKey}";
    }
}
