using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Models;

namespace JWTAuthentication.BL.Interfaces
{
    public interface ITransportService
    {
        Task<List<Transport>> GetAllTransport();

        Task<Transport> GetTransport(int id);

        Task<Transport> UpdateTransport(Transport entity);

        Task<Transport> DeleteTransport(int id);

        Task<Transport> CreateTransport(Transport entity);
    }
}
