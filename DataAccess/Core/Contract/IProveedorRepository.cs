using Common.Utilities.Services;
using Models.Models;
using System.Threading.Tasks;
using System;

namespace DataAccess.Core.Contract
{
    public interface IProveedorRepository
    {
        Task<Response<Object>> GetAll();

        Task<Response<bool>> Create(ProveedorDto request);

        Task<Response<bool>> Update(ProveedorDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
