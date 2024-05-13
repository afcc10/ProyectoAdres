using AutoMapper;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class AdquisicionProfileMap : Profile
    {
        public AdquisicionProfileMap()
        {
            CreateMap<Adquisicion, AdquisicionDto>().ReverseMap();
        }
    }
}
