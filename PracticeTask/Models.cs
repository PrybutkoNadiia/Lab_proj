using System;

namespace WeatherListApp
{
    public enum WeatherType
    {
        Sunny,
        Rainy,
        Cloudy,
        Snowy,
        Foggy,
        Windy
    }

    public class WeatherData
    {
    public WeatherType Type {get; set; }
    public double Temperature {get; set; }
    public bool Precipitation {get; set; }
    

        public WeatherData() { }

        public WeatherData(WeatherType type, double temperature, bool precipitation)
        {
            Type = type;
            Temperature = temperature;
            Precipitation = precipitation;
        }

        public override string ToString()
        {
            return $"{Type,-10} | {Temperature,11:F1}°C | {(Precipitation ? "Yes" : "No"),-13}";
        }
    }

    public class ListNode
    {
        public WeatherData Value { get; set; }
        public ListNode Next { get; set; }
        public ListNode Previous { get; set; }

        public ListNode(WeatherData value)
        {
            Value = value;
        }
    }
}