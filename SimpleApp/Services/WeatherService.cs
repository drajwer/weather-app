using SimpleApp.Dal;
using SimpleApp.Interfaces;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly AppDbContext _context;
        private readonly IWeatherApiClient _apiClient;

        public WeatherService(AppDbContext context, IWeatherApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task UpdateCurrentWeatherAsync()
        {
            var newWeathers = await _apiClient.GetWeatherAsync();
            var oldWeathers = _context.Weathers.ToList();

            foreach (var newWeather in newWeathers)
            {
                var oldWeather = oldWeathers.SingleOrDefault(w => w.CityId == newWeather.CityId);
                if (oldWeather != null)
                {
                    oldWeather.Humidity = newWeather.Humidity;
                    oldWeather.Temperature = newWeather.Temperature;
                    oldWeather.Name = newWeather.Name;
                }
                else
                {
                    _context.Weathers.Add(newWeather);
                }
            }

           

            _context.SaveChanges(); // save changes has its own transaction
        }

        IQueryable<Weather> IWeatherService.GetCurrentWeatherForAllCities()
        {
            return _context.Weathers.AsQueryable();
        }
    }
}
