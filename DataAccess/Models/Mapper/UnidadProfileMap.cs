using AutoMapper;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class UnidadProfileMap : Profile
    {
        public UnidadProfileMap()
        {
            CreateMap<Unidad, UnidadDto>().ReverseMap();
        }
    }
    
}
