using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public GeoLocationService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public async Task<List<LocationResponse>?> GetLocationAsync(string city)
        {
            var apiKey = _configuration.GetValue<string>("APIKey");
            List<LocationResponse>? locationData = new List<LocationResponse>();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={city}&appid={apiKey}");
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                locationData = JsonConvert.DeserializeObject<List<LocationResponse>>(apiResponse);

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return locationData;
        }
    }
}
