using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication.Models;

namespace JWTAuthentication.BL.Interfaces
{
    public interface IPackageService
    {
         Task<List<Package>> GetAllPackages();

         Task<Package> GetPackage(int id);
       
         Task<Package> UpdatePackage(Package entity);

         Task<Package> DeletePackage(int id);

        Task<Package> CreatePackage(Package entity);

        Task<List<Package>> GetPackagesByUserId(int userId);

        Task<List<List<int>>> FindAllRoutes(int start, int end);
        Task<List<RoadsTransportResponseModel>> FindAllRoutsByNames(int start, int end, double volume, double weight);
        Task<List<Transport>> GetAllTransportForDirection(int start, int end);
    }
}
