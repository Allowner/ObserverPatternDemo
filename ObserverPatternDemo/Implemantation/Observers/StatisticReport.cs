//-----------------------------------------------------------------------
// <copyright file="StatisticReport.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class that gets weather condition
    /// </summary>
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private double averageHumidity;
        private double averagePressure;
        private double averageTemperature;
        private WeatherData weatherData;
        private int days;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticReport"/> class.
        /// </summary>
        /// <param name="weatherData">
        /// Observable object
        /// </param>
        public StatisticReport(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Register(this);
        }

        /// <summary>
        /// Method that registers observer
        /// </summary>
        /// <param name="observable">
        /// Observable object
        /// </param>
        public void Register(IObservable<WeatherInfo> observable) => observable.Register(this);

        /// <summary>
        /// Method that removes registration of observer
        /// </summary>
        /// <param name="observable">
        /// Observable object
        /// </param>
        public void Unregister(IObservable<WeatherInfo> observable) => observable.Unregister(this);

        /// <summary>
        /// Method that shows current weather condition
        /// </summary>
        /// <param name="sender">
        /// Observable object
        /// </param>
        /// <param name="info">
        /// Information about weather
        /// </param>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            averageHumidity = this.UpdateAverage(this.averageHumidity, info.Humidity);
            averagePressure = this.UpdateAverage(this.averagePressure, info.Pressure);
            averageTemperature = this.UpdateAverage(this.averageTemperature, info.Temperature);
            Console.WriteLine("--StatisticReport--");
            Console.WriteLine($"Humidity: {this.averageHumidity}\nPressure: {this.averagePressure}\nTemperature: {this.averageTemperature}");
            this.days += 1;
        }

        private double UpdateAverage(double averageParam, double infoParam)
        {
            return ((averageParam * this.days) + infoParam) / (this.days + 1);
        }
    }
}
