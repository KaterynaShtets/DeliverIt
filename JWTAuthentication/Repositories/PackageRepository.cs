using JWTAuthentication.Authentication;
using JWTAuthentication.DAL.EFCore;
using JWTAuthentication.Models;

namespace JWTAuthentication.Repositories
{
    public class PackageRepository : Repository<Package, ApplicationDbContext>
    {
        public PackageRepository(ApplicationDbContext context) : base(context) { }
    }
}
