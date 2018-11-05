using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;
        private float temperature;
        private float humidity;
        private int pressure;

        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            observers.Remove(observer);
        }

        public void Start()
        {
            new Thread(new ThreadStart(Run)).Start();
        }

        void Run()
        {
            WeatherInfo weatherInfo = new WeatherInfo();
            Random random = new Random();
            for(int days = 0; days < 5; days++)
            {
                weatherInfo.Humidity = random.Next(80, 100);
                weatherInfo.Temperature = random.Next(3, 15);
                weatherInfo.Pressure = random.Next(767, 772);
                Notify(this, weatherInfo);
                Thread.Sleep(2000);
            }
        }

        private void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            foreach (var observer in observers)
            {
                observer.Update(sender, info);
            }
        }

        void IObservable<WeatherInfo>.Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            this.Notify(sender, info);
        }

    }
}