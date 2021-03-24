using System.Collections.Generic;
using JWTAuthentication.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JWTAuthentication.Models
{
    public class User : IdentityUser<int>, IEntity
    {
       public int Age { get; set; }
       //public List<Package> Packages { get; set; }
    }
}
