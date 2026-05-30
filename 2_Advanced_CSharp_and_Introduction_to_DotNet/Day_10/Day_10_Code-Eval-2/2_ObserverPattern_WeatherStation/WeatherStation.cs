using System.Collections.Generic;

namespace _2_ObserverPattern_WeatherStation {
    public class WeatherStation {
        private List<IWeatherObserver> _observers = new List<IWeatherObserver>();
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public void RegisterObserver(IWeatherObserver observer) {
            _observers.Add(observer);
            System.Console.WriteLine($"Observer registered: {observer.GetType().Name}");
        }

        public void UnregisterObserver(IWeatherObserver observer) {
            _observers.Remove(observer);
            System.Console.WriteLine($"Observer unregistered: {observer.GetType().Name}");
        }

        public void SetWeatherData(float temperature, float humidity, float pressure) {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            NotifyObservers();
        }

        private void NotifyObservers() {
            foreach (var observer in _observers) {
                observer.Update(_temperature, _humidity, _pressure);
            }
        }
    }
}