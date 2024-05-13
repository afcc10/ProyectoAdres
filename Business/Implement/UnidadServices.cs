using AutoMapper;
using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class UnidadServices : IUnidadServices
    {
        #region Propierties
        private readonly IUnidadRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UnidadServices(IUnidadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<UnidadDto>>> GetAll()
        {
            var result = await _repository.GetAll();

            Response<List<UnidadDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<UnidadDto>>(result.ObjectResponse)
                                    : null
            };
            return response;
        }

        public async Task<Response<bool>> Update(UnidadDto request)
        {
            var result = await _repository.Update(request);
            return result;
        }

        public async Task<Response<bool>> Create(UnidadDto request)
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
