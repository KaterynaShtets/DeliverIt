using JWTAuthentication.Interfaces;

namespace JWTAuthentication.Models
{
    public class Package : IEntity
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public string Material { get; set; }
        public User User { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public string CitiesIds { get; set; }
    }
}
