using System;
using AutoMapper;
using DataAccess.Models;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class StudentProfileMap : Profile
    {
        public StudentProfileMap()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
