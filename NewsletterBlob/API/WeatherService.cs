using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Windows.Forms;
using System.Net.Http;

namespace NewsletterBlob.API
{
    public class WeatherService
    {
        private string apiKey = "31d31cf1cc5fa36eea92ecb1c69be7b7";
        private string apiUrl = "https://api.openweathermap.org/data/2.5/weather";
        public async Task<WeatherInfo> GetWeatherInfo(string city)
        {
            string encodedCity = Uri.EscapeDataString(city);

            // Constrói a URL da API com a chave de API e a cidade
            string url = $"{apiUrl}?q={Uri.EscapeDataString(city)}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json);

                    WeatherInfo info = new WeatherInfo();
                    info.City = NormalizeCityName(data["name"].ToString());
                    info.Temperature = NormalizeTemperature(data["main"]["temp"].ToString());

                    return info;
                }
                else
                {
                    // Handle the API error response
                    throw new Exception("Failed to retrieve weather information.");
                }
            }
        }

        private string NormalizeCityName(string cityName)
        {
            Encoding utf8Encoding = Encoding.UTF8;
            byte[] bytes = utf8Encoding.GetBytes(cityName);
            string normalizedCityName = utf8Encoding.GetString(bytes);

            return normalizedCityName;
        }

        private string NormalizeTemperature(string temperature)
        {
            return temperature.Replace(',', '.');
        }
    }
}
