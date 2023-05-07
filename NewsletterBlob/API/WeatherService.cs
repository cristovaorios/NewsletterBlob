using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace NewsletterBlob.API
{
    internal class WeatherService
    {
        private string apiKey = "31d31cf1cc5fa36eea92ecb1c69be7b7";
        private string apiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherInfo GetWeatherInfo(string city)
        {
            // Constrói a URL da API com a chave de API e a cidade
            string url = $"{apiUrl}?q={city}&appid={apiKey}&units=metric";

            // Faz uma solicitação HTTP para a API e obtém a resposta como uma string JSON
            WebClient client = new WebClient();
            string json = client.DownloadString(url);

            // Analisa a string JSON para obter as informações de tempo/clima
            JObject data = JObject.Parse(json);
            WeatherInfo info = new WeatherInfo();
            info.City = data["name"].ToString();
            info.Temperature = data["main"]["temp"].ToString();

            return info;
        }
    }
}
