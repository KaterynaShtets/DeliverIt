using JWTAuthentication.Interfaces;

namespace JWTAuthentication.Models
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
