using JWTAuthentication.DAL.Interfaces;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController
    {
        private readonly IRepository<City> _cityRepository;

        public CityController(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _cityRepository.GetAll();
        }
    }
}
