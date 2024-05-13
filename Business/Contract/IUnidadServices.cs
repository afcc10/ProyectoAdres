using Common.Utilities.Services;
using Models.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Business.Contract
{
    public interface IUnidadServices
    {
        Task<Response<List<UnidadDto>>> GetAll();

        Task<Response<bool>> Create(UnidadDto request);

        Task<Response<bool>> Update(UnidadDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
