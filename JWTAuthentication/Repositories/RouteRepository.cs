using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Authentication;
using JWTAuthentication.DAL.EFCore;
using JWTAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Repositories
{
    public class RouteRepository : Repository<Route, ApplicationDbContext>
    {
        public RouteRepository(ApplicationDbContext context) : base(context) { }

        public async override Task<List<Route>> GetAll()
        {
            return await _entities.Include(x => x.Transport).ThenInclude(x => x.TransportType).ToListAsync();
        }
    }
}
