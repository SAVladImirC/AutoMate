using System.Text.Json.Serialization;

namespace Data.ValueObjects
{
    public readonly struct Location
    {
        public double Latitude { get; }
        public double Longitude { get; }

        [JsonConstructor]
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{Longitude}N{Latitude}E";
        }
    }
}
