using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleApp.Interfaces;
using SimpleApp.Models;
using SimpleApp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleApp.Services
{
    public class OpenWeatherClient : IWeatherApiClient
    {
        private OpenWeatherClientOptions options;
        public OpenWeatherClient(IOptions<OpenWeatherClientOptions> optionsAccessor)
        {
            options = optionsAccessor.Value;
        }
        public async Task<IEnumerable<Weather>> GetWeatherAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(options.CitiesUrl);
                var json = await response.Content.ReadAsStringAsync();

                return ParseJson(json);
            }
        }

        // In real app custom JsonConverter should be used.
        private List<Weather> ParseJson(string json)
        {
            try
            {
                List<Weather> weathers = new List<Weather>();
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var list = jObject["list"];

                foreach (var item in list)
                {
                    var main = item["main"];
                    var weather = new Weather()
                    {
                        CityId = item["id"],
                        CityName = item["name"],
                        Humidity = main["humidity"],
                        Temperature = main["temp"],
                        Name = item["weather"][0]["main"]
                    };
                    weathers.Add(weather);
                }

                return weathers;
            }
            catch (Exception ex )
            {
                return new List<Weather>();
            }
            
        }
     
    }
}
