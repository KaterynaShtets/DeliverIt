using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.BL.Interfaces;
using JWTAuthentication.DAL.Interfaces;
using JWTAuthentication.Models;

namespace JWTAuthentication.BL.Services
{
    public class PackageService : IPackageService
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IRepository<Transport> _transportRepository;
        private readonly IRepository<Route> _routeRepository;
        private readonly IRepository<City> _cityRepository;

        public PackageService(IRepository<Package> packageRepository, IRepository<Transport> transportRepository, IRepository<Route> routeRepository, IRepository<City> cityRepository)
        {
            _packageRepository = packageRepository;
            _transportRepository = transportRepository;
            _routeRepository = routeRepository;
            _cityRepository = cityRepository;
        }

        public async Task<Package> CreatePackage(Package entity)
        {
            return await _packageRepository.Add(entity);
        }

        public async Task<List<Package>> GetAllPackages()
        {
            return await _packageRepository.GetAll();
        }

        public async Task<Package> GetPackage(int id)
        {
            return await _packageRepository.Get(id);
        }

        public async Task<List<Package>> GetPackagesByUserId(int userId)
        {
            var products = await _packageRepository.GetAll();
            return products.Where(x => x.User.Id == userId).ToList();
        }

        public async Task<Package> UpdatePackage(Package entity)
        {
            return await _packageRepository.Update(entity);
        }

        public async Task<Package> DeletePackage(int id)
        {
            return await _packageRepository.Delete(id);
        }

        public async Task<List<Transport>> GetAllTransportForDirection(int start, int end)
        {
            var routes = await _routeRepository.GetAll();
            var transport = routes.Where(x => x.FromCityId == start && x.ToCityId == end).Select(x => x.Transport).ToList();
            return transport;
        }

        public async Task<List<List<int>>> FindAllRoutes(int start, int end)
        {
            var allRoutes = await _routeRepository.GetAll();
            var allCities = await _cityRepository.GetAll();
            var count = allCities.Count;
            Graph g = new Graph(10);
            foreach (var record in allRoutes)
            {
                g.addEdge(record.FromCityId, record.ToCityId);
            }
            g.printAllPaths(start, end);
            return g.resultList;
        }

        public async Task<List<RoadsTransportResponseModel>> FindAllRoutsByNames(int start, int end, double volume, double weight)
        {
            var resultListOfCityRoads = new List<RoadsTransportResponseModel>();
            var listOfRoads = await FindAllRoutes(start, end);
            var cities = await _cityRepository.GetAll();
            var routes = await _routeRepository.GetAll();
            foreach (var list in listOfRoads)
            {
                var transportResponseModels = new List<TransportResponseModel>();
                var stringList = new RoadsTransportResponseModel();
                stringList.Cities = new List<City>();
                for (var  i = 0; i < list.Count - 1; i++)
                {
                  
                    var from = cities.Where(n => n.Id == list[i]).FirstOrDefault();
                    var to = cities.Where(n => n.Id == list[i + 1]).FirstOrDefault();
                    if (i == 0)
                    {
                        stringList.Cities.Add(from);
                    }
                        stringList.Cities.Add(to);

                    transportResponseModels.Add(routes.Where(x => x.FromCityId == list[i] && x.ToCityId == list[i + 1]
                        && x.Transport.MaxVolume >= volume && x.Transport.MaxWeight >= weight) 
                        .Select(x => new {
                            Price = x.Distance * x.Transport.PricePerKm + x.Transport.PricePerKg * weight + x.Transport.PricePerM3 * volume,
                            x.Transport.TransportType,
                            Time = x.Distance / x.Transport.AverageSpeedPerKm
                        }).GroupBy(x => new { x.Price, x.Time })
                        .Select(x => new TransportResponseModel { 
                            Price = x.Sum(y => y.Price),
                            Time = x.Sum(y => y.Time),
                            TransportTypes = x.Select(y => y.TransportType).ToList()
                        }).FirstOrDefault());
                }

                stringList.Transport = new TransportResponseModel
                {
                    Price = transportResponseModels.Sum(x => x.Price),
                    Time = transportResponseModels.Sum(x => x.Time),
                    TransportTypes = transportResponseModels.SelectMany(x => x.TransportTypes).ToList()
                };
                resultListOfCityRoads.Add(stringList);
            }

            return resultListOfCityRoads;
        }
    }
}
