using Common.Utilities.Services;
using Models.Models;
using System.Threading.Tasks;
using System;

namespace DataAccess.Core.Contract
{
    public interface IServicioRepository
    {
        Task<Response<Object>> GetAll();

        Task<Response<bool>> Create(ServicioDto request);

        Task<Response<bool>> Update(ServicioDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
