using System.Collections.Generic;

namespace JWTAuthentication.Models
{
    public class RoadsTransportResponseModel
    {
        public List<City> Cities { get; set; }
        public TransportResponseModel Transport { get; set; }
    }
}
