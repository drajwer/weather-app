using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Interfaces
{
    public interface IWeatherApiClient
    {
        Task<IEnumerable<Weather>> GetWeatherAsync();
    }
}
