using AutoMapper;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Helpers;

namespace Draw.Business.Mapper
{
    internal class DTOMapper:Profile
    {
        public DTOMapper()
        {
            CreateMap<ColorDTO, Color>().ReverseMap();
        }
    }
}
