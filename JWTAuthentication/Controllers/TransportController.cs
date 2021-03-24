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
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _service;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public TransportController(ITransportService service, ApplicationDbContext context,
            UserManager<User> userManager)
        {
            _service = service;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Transport>> Create(Transport entity)
        {
            return await _service.CreateTransport(entity);
        }

        [HttpGet]
        [Route("getAllTransport")]
        public async Task<ActionResult<List<Transport>>> Get()
        {
            return await _service.GetAllTransport();
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Transport>> Update(Transport entity)
        {
            return await _service.UpdateTransport(entity);
        }

        [HttpDelete(/*"{id}"*/)]
        [Route("delete")]
        public async Task<ActionResult<Transport>> Delete(int id)
        {
            return await _service.DeleteTransport(id);
        }
    }
}
