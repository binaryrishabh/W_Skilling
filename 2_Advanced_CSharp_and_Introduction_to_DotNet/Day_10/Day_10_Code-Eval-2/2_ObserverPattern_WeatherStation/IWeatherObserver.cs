namespace _2_ObserverPattern_WeatherStation {
    public interface IWeatherObserver {
        void Update(float temperature, float humidity, float pressure);
    }
}