using System;

namespace API_exploration
{
    public class WeatherForecast
    {
        public int id { get; set; }
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int RainChance { get; set; }

        public string Summary { get; set; }
    }
}
