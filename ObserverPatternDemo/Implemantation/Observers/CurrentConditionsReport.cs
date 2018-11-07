//-----------------------------------------------------------------------
// <copyright file="CurrentConditionsReport.cs" company="No company">
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
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherData weatherData;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentConditionsReport"/> class.
        /// </summary>
        /// <param name="weatherData">
        /// Observable object
        /// </param>
        public CurrentConditionsReport(WeatherData weatherData)
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
            Console.WriteLine("--CurrentReport--");
            Console.WriteLine($"Humidity: {info.Humidity}\nPressure: {info.Pressure}\nTemperature: {info.Temperature}");
        }
    }
}