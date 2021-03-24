using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Authentication;
using JWTAuthentication.DAL.EFCore;
using JWTAuthentication.Models;

namespace JWTAuthentication.Repositories
{
    public class TransportRepository : Repository<Transport, ApplicationDbContext>
    {
        public TransportRepository(ApplicationDbContext context) : base(context) { }
    }
}
