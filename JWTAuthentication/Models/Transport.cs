using JWTAuthentication.Interfaces;

namespace JWTAuthentication.Models
{
    public class Transport : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MaxWeight { get; set; }
        public double MaxVolume { get; set; }
        public double PricePerKm { get; set; }
        public double PricePerKg { get; set; }
        public double PricePerM3 { get; set; }
        public double AverageSpeedPerKm { get; set; }
        public TransportType TransportType { get; set; }
    }
}
