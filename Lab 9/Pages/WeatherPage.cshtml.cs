using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Lab_9.Pages
{
    public class WeatherPage : PageModel
    {
        private const string url = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&appid=32e6ad85dc05cdc5cb3d1cc0aa578b66&units=metric";

        public string? Message { get; set; }

        public string? WeatherName { get; set; }
        public double WeatherTemp { get; set; }
        public double WeatherFeelsLike { get; set; }
        public string? WeatherMain { get; set; }

        public async Task OnGet()
        {
            WeatherData weatherData = await GetWeather();
    
            WeatherName = weatherData.Name;
            WeatherTemp = weatherData.Main.Temp;
            WeatherFeelsLike = weatherData.Main.Feels_Like;
            WeatherMain = weatherData.Weather[0].Main; // Отримайте значення з першого елемента масиву

            Message = $"Погода в місті {WeatherName}: {WeatherMain}, Температура - {WeatherTemp}\u00b0C, Відчувається як - {WeatherFeelsLike}\u00b0C";
        }

        public async Task<WeatherData> GetWeather()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            
            WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(response)!;

            return weatherData;
        }
    }
    
    public class WeatherData
    {
        public string Name { get; set; }
        public MainData Main { get; set; }
        public Weather[] Weather { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
    }
}