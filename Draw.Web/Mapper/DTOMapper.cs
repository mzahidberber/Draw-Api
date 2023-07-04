using AutoMapper;
using Draw.Core.DTOs.Concrete;
using Draw.Web.Models;

namespace Draw.Web.Mapper
{
    internal class DTOMapper:Profile
    {
        public DTOMapper()
        {
            

            CreateMap<MainTitleDTO, MainTitle>().ReverseMap();
            CreateMap<BaseTitleDTO, BaseTitle>().ReverseMap();
            CreateMap<SubTitleDTO, SubTitle>().ReverseMap();

        }
    }
}
