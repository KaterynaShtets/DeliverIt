using System.Collections.Generic;
using JWTAuthentication.Interfaces;

namespace JWTAuthentication.Models
{
    public class TransportType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
