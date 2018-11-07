//-----------------------------------------------------------------------
// <copyright file="WeatherData.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class that gets weather data and sends it to observers
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        /// <summary>
        /// Field that stores observers
        /// </summary>
        private List<IObserver<WeatherInfo>> observers;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherData" /> class.
        /// </summary>
        public WeatherData() => this.observers = new List<IObserver<WeatherInfo>>();

        /// <summary>
        /// Registers new observer.
        /// </summary>
        /// <param name="observer">
        /// Observer to register.
        /// </param>
        public void Register(IObserver<WeatherInfo> observer) => this.observers.Add(observer);

        /// <summary>
        /// Removes observer.
        /// </summary>
        /// <param name="observer">
        /// Observer to remove.
        /// </param>
        public void Unregister(IObserver<WeatherInfo> observer) => this.observers.Remove(observer);

        /// <summary>
        /// Creates new thread.
        /// </summary>
        public void Start() => new Thread(new ThreadStart(this.Run)).Start();

        void IObservable<WeatherInfo>.Notify(WeatherInfo info) => this.Notify(info);

        protected virtual void Notify(WeatherInfo info)
        {
            foreach (var observer in this.observers)
            {
                observer.Update(this, info);
            }
        }

        private void Run()
        {
            WeatherInfo weatherInfo = new WeatherInfo();
            Random random = new Random();
            for (int days = 0; days < 5; days++)
            {
                weatherInfo.Humidity = random.Next(80, 100);
                weatherInfo.Temperature = random.Next(3, 15);
                weatherInfo.Pressure = random.Next(767, 772);
                this.Notify(weatherInfo);
                Thread.Sleep(2000);
            }
        }
    }
}