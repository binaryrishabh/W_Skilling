using System;

namespace _2_ObserverPattern_WeatherStation {
    public class WeatherDisplay : IWeatherObserver {
        private string _displayName;

        public WeatherDisplay(string name) {
            _displayName = name;
        }

        public void Update(float temperature, float humidity, float pressure) {
            Console.WriteLine($"[{_displayName}] Temp: {temperature}°C | Humidity: {humidity}% | Pressure: {pressure} hPa");
        }
    }
}