using Microsoft.AspNetCore.Mvc;
using SimpleApp.Interfaces;
using SimpleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        IWeatherService _weatherService;
        IAuthService _authService;

        public WeatherController(IWeatherService weatherService, IAuthService authService)
        {
            _weatherService = weatherService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetWeather()
        {
            var vm = _weatherService.GetCurrentWeatherForAllCities();
            return Ok(vm);
        }

        // Method is not idempotent, so POST is used.
        [HttpPost("update")]
        public async Task<IActionResult> UpdateWeatherAsync([FromBody] LoginViewModel vm)
        {
            if (!_authService.IsAdmin(vm.Password))
                return Unauthorized();

            await _weatherService.UpdateCurrentWeatherAsync();
            return NoContent();
        }
    }
}
