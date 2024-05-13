using Common.Utilities.Services;
using Models.Models;
using System.Threading.Tasks;
using System;

namespace DataAccess.Core.Contract
{
    public interface IUnidadRepository
    {
        Task<Response<Object>> GetAll();

        Task<Response<bool>> Create(UnidadDto request);

        Task<Response<bool>> Update(UnidadDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
