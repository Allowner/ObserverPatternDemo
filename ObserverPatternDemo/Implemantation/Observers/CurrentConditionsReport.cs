using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherData weatherData;

        public CurrentConditionsReport(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Register(this);
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            Console.WriteLine("--CurrentReport--");
            Console.WriteLine($"Humidity: {info.Humidity}\nPressure: {info.Pressure}\nTemperature: {info.Temperature}");
        }
    }
}