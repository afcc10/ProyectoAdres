using Common.Utilities.Services;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IProveedorServices
    {
        Task<Response<List<ProveedorDto>>> GetAll();

        Task<Response<bool>> Create(ProveedorDto request);

        Task<Response<bool>> Update(ProveedorDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
