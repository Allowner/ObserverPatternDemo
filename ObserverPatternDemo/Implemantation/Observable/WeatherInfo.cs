//-----------------------------------------------------------------------
// <copyright file="WeatherInfo.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class that contains weather information.
    /// </summary>
    public class WeatherInfo : EventInfo
    {
        /// <summary>
        /// Gets or sets temperature
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Gets or sets humidity
        /// </summary>
        public int Humidity { get; set; }

        /// <summary>
        /// Gets or sets pressure
        /// </summary>
        public int Pressure { get; set; }
    }
}