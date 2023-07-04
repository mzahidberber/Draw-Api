using AutoMapper;
using Draw.Core.Services.Model;
using Draw.Entities.Concrete.Draw;

namespace Draw.Core.Mapper
{
    internal class DTOMapper:Profile
    {
        public DTOMapper()
        {
            CreateMap<Point, PointGeo>()
                .ForMember(dest => dest.X, opt => opt.MapFrom(x => x.X))
                .ForMember(dest => dest.Y, opt => opt.MapFrom(x => x.Y))
                .ReverseMap();

            //CreateMap<GeoRequest<RadiusAndPCenter>,GeoRequest<RadiusAndPGeoCenter>>()
            //    .ForMember(dest=>dest.data.centerPoint,opt=>opt.MapFrom(x=>x.))
            
        }
    }
}
