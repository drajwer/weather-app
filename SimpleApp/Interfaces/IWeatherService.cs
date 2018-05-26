using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Interfaces
{
    public interface IWeatherService
    {
        Task UpdateCurrentWeatherAsync();
        IQueryable<Weather> GetCurrentWeatherForAllCities(); // IQueryable can be useful, if quering on large table needed.
    }
}
