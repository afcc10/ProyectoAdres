using AutoMapper;
using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class ProveedorServices : IProveedorServices
    {
        #region Propierties
        private readonly IProveedorRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProveedorServices(IProveedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<ProveedorDto>>> GetAll()
        {
            var result = await _repository.GetAll();

            Response<List<ProveedorDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<ProveedorDto>>(result.ObjectResponse)
                                    : null
            };
            return response;
        }

        public async Task<Response<bool>> Update(ProveedorDto request)
        {
            var result = await _repository.Update(request);
            return result;
        }

        public async Task<Response<bool>> Create(ProveedorDto request)
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
