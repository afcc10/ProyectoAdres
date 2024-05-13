using AutoMapper;
using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class StudentServices : IStudentServices
    {
        #region Propierties
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentServices(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        
        #endregion

        public async Task<Response<List<StudentDto>>> GetStudents()
        {
            var result = await _studentRepository.GetStudents();

            Response<List<StudentDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<StudentDto>>(result.ObjectResponse)
                                    : null
            };

            return response;
        }

        public async Task<Response<bool>> UpdateStudent(StudentDto student)
        {
            var result = await _studentRepository.UpdateStudent(student);
            return result;
        }

        public async Task<Response<bool>> CreateStudent(StudentDto student)
        {
            var result = await _studentRepository.CreateStudent(student);
            return result;
        }

        public async Task<Response<bool>> DeleteByIdStudent(int id)
        {
            var result = await _studentRepository.DeleteByIdStudent(id);
            return result;
        }

        public async Task<Response<StudentDto>> GetByIdStudent(int id)
        {
            var result = await _studentRepository.GetByIdStudent(id);
            return result;
        }
    }
}
