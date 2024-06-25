
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Xml.Serialization;
using WeatherApp.Models;
using Xml2CSharp;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public WeatherService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(float lat, float lon)
        {
            var apiKey = _configuration.GetValue<string>("APIKey");
            WeatherResponse? weatherData = new WeatherResponse();


            try
            {
                HttpResponseMessage? response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}");
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherResponse>(apiResponse);

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return weatherData;
        }

        public async Task<WeatherXMLResponse?> GetWeatherXMLAsync(float lat, float lon, string responseType)
        {
            var apiKey = _configuration.GetValue<string>("APIKey");
            WeatherXMLResponse? weatherXMLData = new WeatherXMLResponse();
            try
            {
                HttpResponseMessage? response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&mode={responseType}&appid={apiKey}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStreamAsync();

                XmlSerializer serializer = new XmlSerializer(typeof(WeatherXMLResponse));
                weatherXMLData = serializer.Deserialize(apiResponse) as WeatherXMLResponse;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return weatherXMLData;
        }
    }
}
