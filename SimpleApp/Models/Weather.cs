using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    // This can be split into two models: city and weather.
    public class Weather
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public string Name { get; set; }
    }
}
