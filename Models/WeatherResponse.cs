﻿namespace WeatherApp.Models
{

    public class WeatherResponse
    {
        public Coord? Coord { get; set; }
        public Weather[]? Weather { get; set; }
        public string? Base { get; set; }
        public Main? Main { get; set; }
        public int Visibility { get; set; }
        public Wind? Wind { get; set; }
        public Rain? Rain { get; set; }
        public Clouds? Clouds { get; set; }
        public int Dt { get; set; }
        public Sys? sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Cod { get; set; }
    }

    public class Coord
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float FeelsLike { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public int Pressure { get; set; }
        public int humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
    }

    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
        public float Qust { get; set; }
    }

    public class Rain
    {
        public float _1h { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string? Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }

}
