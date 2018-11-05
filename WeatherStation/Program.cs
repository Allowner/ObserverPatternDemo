using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;
using System;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weather = new WeatherData();
            CurrentConditionsReport observer = new CurrentConditionsReport(weather);
            StatisticReport statisticObserver = new StatisticReport(weather);
            weather.Start();
            Console.Read();
        }
    }
}
