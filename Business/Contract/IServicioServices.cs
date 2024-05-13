using Common.Utilities.Services;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IServicioServices
    {
        Task<Response<List<ServicioDto>>> GetAll();

        Task<Response<bool>> Create(ServicioDto request);

        Task<Response<bool>> Update(ServicioDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
