using System;

namespace _2_ObserverPattern_WeatherStation {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=== Weather Station Observer Pattern Demo ===\n");

            var weatherStation = new WeatherStation();

            // Create displays (Indian names)
            var display1 = new WeatherDisplay("PR");
            var display2 = new WeatherDisplay("pr");
            var display3 = new WeatherDisplay("Prarish");

            // Register observers
            Console.WriteLine("--- Registering Observers ---");
            weatherStation.RegisterObserver(display1);
            weatherStation.RegisterObserver(display2);
            weatherStation.RegisterObserver(display3);

            Console.WriteLine("\n--- Weather Updates ---");
            weatherStation.SetWeatherData(32.5f, 65.0f, 1012.0f);

            System.Threading.Thread.Sleep(1000);
            weatherStation.SetWeatherData(28.0f, 78.5f, 1008.5f);

            Console.WriteLine("\n--- Unregistering PR ---");
            weatherStation.UnregisterObserver(display2);

            Console.WriteLine("\n--- Final Weather Update ---");
            weatherStation.SetWeatherData(26.5f, 70.0f, 1015.0f);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}