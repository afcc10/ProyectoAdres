using Common.Utilities.Services;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IAdquisicionesServices
    {
        Task<Response<List<AdquisicionDto>>> GetAll();

        Task<Response<bool>> Create(AdquisicionDto request);

        Task<Response<bool>> Update(AdquisicionDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
