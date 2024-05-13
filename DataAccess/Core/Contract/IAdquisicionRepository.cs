using Common.Utilities.Services;
using Models.Models;
using System.Threading.Tasks;
using System;

namespace DataAccess.Core.Contract
{
    public interface IAdquisicionRepository
    {
        Task<Response<Object>> GetAll();

        Task<Response<bool>> Create(AdquisicionDto request);

        Task<Response<bool>> Update(AdquisicionDto request);

        Task<Response<bool>> DeleteById(int id);
    }
}
