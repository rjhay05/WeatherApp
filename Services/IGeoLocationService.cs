using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IGeoLocationService
    {
        /// <summary>
        /// Gets the geo location
        /// </summary>
        /// <param name="city">City to locate</param>
        /// <returns>returns Dictionary of data location</returns>
        public  Task<List<LocationResponse>?> GetLocationAsync(string city);
    }
}
