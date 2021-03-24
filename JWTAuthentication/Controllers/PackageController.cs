using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JWTAuthentication.Authentication;
using JWTAuthentication.BL.Interfaces;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public PackageController(IPackageService service, ApplicationDbContext context, 
            UserManager<User> userManager)
        {
            _service = service;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Package>> Create(Package entity)
        {
            var name = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            entity.User = await _userManager.FindByNameAsync(name);
            return await _service.CreatePackage(entity);
        }

        [HttpGet]
        [Route("getAllPackages")]
        public async Task<ActionResult<List<Package>>> Get()
        {
            return await _service.GetAllPackages();
        }

        [HttpGet(/*"{id}"*/)]
        [Route("getPackageById")]
        public async Task<ActionResult<Package>> GetOne(int id)
        {
            return await _service.GetPackage(id);
        }

        [HttpGet]
        [Route("getUserPackages")]
        public async Task<List<Package>> GetPackagesByUserId()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await _service.GetPackagesByUserId(userId);
        }

        [HttpGet]
        [Route("getAllRoutes")]
        public async Task<List<List<int>>> GetAllRoutes(int fromCity, int toCity)
        {
            return await _service.FindAllRoutes(fromCity, toCity);
        }

        [HttpGet]
        [Route("getAllRoutesString")]
        public async Task<List<RoadsTransportResponseModel>> GetAllRoutesString([FromQuery] GetRoutesRequest request)
        {
            return await _service.FindAllRoutsByNames(request.FromCity, request.ToCity, request.Height * request.Length * request.Width, request.Weight);
        }

        [HttpGet]
        [Route("getAllTransportForDirection")]
        public async Task<List<Transport>> GetAllTransportForDirection(int fromCity, int toCity)
        {
            return await _service.GetAllTransportForDirection(fromCity, toCity);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Package>> Update(Package entity)
        {
            return await _service.UpdatePackage(entity);
        }

        [HttpDelete(/*"{id}"*/)]
        [Route("delete")]
        public async Task<ActionResult<Package>> Delete(int id)
        {
            return await _service.DeletePackage(id);
        }
    }
}
