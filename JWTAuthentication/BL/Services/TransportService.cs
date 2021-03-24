using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.BL.Interfaces;
using JWTAuthentication.DAL.Interfaces;
using JWTAuthentication.Models;
using JWTAuthentication.Repositories;

namespace JWTAuthentication.BL.Services
{
    public class TransportService: ITransportService
    {
        private readonly IRepository<Transport> _transportRepository;

        public TransportService(IRepository<Transport> transportRepository)
        {
            _transportRepository = transportRepository;
        }

        public async Task<Transport> CreateTransport(Transport entity)
        {
            return await _transportRepository.Add(entity);
        }

        public async Task<List<Transport>> GetAllTransport()
        {
            return await _transportRepository.GetAll();
        }

        public async Task<Transport> GetTransport(int id)
        {
            return await _transportRepository.Get(id);
        }

        public async Task<Transport> UpdateTransport(Transport entity)
        {
            return await _transportRepository.Update(entity);
        }

        public async Task<Transport> DeleteTransport(int id)
        {
            return await _transportRepository.Delete(id);
        }
    }
}
