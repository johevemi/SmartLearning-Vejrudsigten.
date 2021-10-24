using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vejrudsigten.Services
{
    public static class WeatherForecast
    {
        public static async Task<string> GetForecastAsync(string key)
        {
            WeatherService service = new WeatherService();
            var todayInfo = await service.GetTodaysWeather(key, "Kolding");
            var yesterdayInfo = await service.GetYesterdaysWeather(key, "Kolding");

            var wmc = new WeatherMessageCreator();

            return wmc.GetWeatherMessage(todayInfo.Conditions, todayInfo.Temperature, yesterdayInfo.Conditions, yesterdayInfo.Temperature);
        }
    }
}
