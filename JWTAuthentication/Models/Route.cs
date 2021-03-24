using JWTAuthentication.Interfaces;

namespace JWTAuthentication.Models
{
    public class Route : IEntity
    {
        public int Id { get; set; }
        public Transport Transport { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public double Distance { get; set; }
    }
}
