using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Authentication;
using JWTAuthentication.DAL.EFCore;
using JWTAuthentication.Models;

namespace JWTAuthentication.Repositories
{
    public class CityRepository : Repository<City, ApplicationDbContext>
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }
    }
}
