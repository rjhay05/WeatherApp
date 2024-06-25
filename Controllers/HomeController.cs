using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _weatherService;
        private readonly IGeoLocationService _geoLocationService;

        public HomeController(ILogger<HomeController> logger, IWeatherService weatherService, IGeoLocationService geoLocationService)
        {
            _logger = logger;
            _weatherService = weatherService;
            _geoLocationService = geoLocationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("get-weather")]
        public async Task<IActionResult> GetWeather([FromBody] List<string> data)
        {
            if (data == null || string.IsNullOrEmpty(data[1]))
                return BadRequest(nameof(data));

            var location = (await _geoLocationService.GetLocationAsync(data[1]))?.FirstOrDefault();

            if (location == null)
                return StatusCode(500);

            if (data[0] == "xml")
            {
                return Ok(await _weatherService.GetWeatherXMLAsync(location.Lat, location.Lon, data[0]));
            }

            var weather = await _weatherService.GetWeatherAsync(location.Lat, location.Lon);

            return Ok(weather);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}