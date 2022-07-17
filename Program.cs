using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter the API key: ");
            var api_Key = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();

                Console.WriteLine("Enter city name: ");

                var city_name = Console.ReadLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";

                var response = client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formattedResponse);

                Console.WriteLine();

                Console.WriteLine("Would you like to enter a different city?");

                var userInput = Console.ReadLine();

                Console.WriteLine();

                if (userInput.ToLower() == "no")
                {
                    break;
                }

            }

        }
    }
}
