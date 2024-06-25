using WeatherApp.Models;
using Xml2CSharp;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        public Task<WeatherResponse?> GetWeatherAsync(float lat, float lon);
        public Task<WeatherXMLResponse?> GetWeatherXMLAsync(float lat, float lon, string responseType);
    }
}
