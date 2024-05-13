using AutoMapper;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class ProveedorProfileMap : Profile
    {
        public ProveedorProfileMap()
        {
            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        }
    }
}
