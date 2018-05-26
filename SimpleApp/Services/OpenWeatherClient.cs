using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SimpleApp.Interfaces;
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
        public async Task<object> GetWeatherAsync(IEnumerable<string> cityIds)
        {
            ValidateCities(cityIds);
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(options.CitiesUrl(cityIds));
                var json = await response.Content.ReadAsStringAsync();

                return JObject.Parse(json);
            }
        }

        private static void ValidateCities(IEnumerable<string> cityIds)
        {
            if (cityIds == null)
                throw new ArgumentNullException();
            if (!cityIds.Any())
                throw new ArgumentException();
        }
    }
}
