using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private double averageHumidity;
        private double averagePressure;
        private double averageTemperature;
        private WeatherData weatherData;
        private int days;

        public StatisticReport(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Register(this);
        }

        public void Register(IObservable<WeatherInfo> observable) => observable.Register(this);

        public void Unregister(IObservable<WeatherInfo> observable) => observable.Unregister(this);

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            averageHumidity = UpdateAverage(averageHumidity, info.Humidity);
            averagePressure = UpdateAverage(averagePressure, info.Pressure);
            averageTemperature = UpdateAverage(averageTemperature, info.Temperature);
            Console.WriteLine("--StatisticReport--");
            Console.WriteLine($"Humidity: {averageHumidity}\nPressure: {averagePressure}\nTemperature: {averageTemperature}");
            days += 1;
        }

        private double UpdateAverage(double averageParam, double infoParam)
        {
            return (averageParam * days + infoParam) / (days + 1);
        }
    }
}
