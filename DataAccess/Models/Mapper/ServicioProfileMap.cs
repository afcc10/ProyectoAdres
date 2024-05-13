using AutoMapper;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class ServicioProfileMap : Profile
    {
        public ServicioProfileMap()
        {
            CreateMap<Servicio, ServicioDto>().ReverseMap();
        }    
    }
}
