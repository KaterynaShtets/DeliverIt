using System.Collections.Generic;

namespace JWTAuthentication.Models
{
    public class TransportResponseModel
    {
        public double Price { get; set; }
        public double Time { get; set; }
        public List<TransportType> TransportTypes { get; set; }
    }
}
