using AutoMapper;
using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class ServicioServices : IServicioServices
    {
        #region Propierties
        private readonly IServicioRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ServicioServices(IServicioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<ServicioDto>>> GetAll()
        {
            var result = await _repository.GetAll();

            Response<List<ServicioDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<ServicioDto>>(result.ObjectResponse)
                                    : null
            };
            return response;
        }

        public async Task<Response<bool>> Update(ServicioDto request)
        {
            var result = await _repository.Update(request);
            return result;
        }

        public async Task<Response<bool>> Create(ServicioDto request)
        {
            var result = await _repository.Create(request);
            return result;
        }

        public async Task<Response<bool>> DeleteById(int id)
        {
            var result = await _repository.DeleteById(id);
            return result;
        }
    }
}
