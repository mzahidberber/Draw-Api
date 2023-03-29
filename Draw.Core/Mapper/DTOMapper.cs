using AutoMapper;
using Draw.Core.Services.Model;
using Draw.Entities.Concrete;

namespace Draw.Core.Mapper
{
    internal class DTOMapper:Profile
    {
        public DTOMapper()
        {
            CreateMap<Point, PointGeo>()
                .ForMember(dest => dest.X, opt => opt.MapFrom(x => x.PointX))
                .ForMember(dest => dest.Y, opt => opt.MapFrom(x => x.PointY))
                .ReverseMap();

            //CreateMap<GeoRequest<RadiusAndPCenter>,GeoRequest<RadiusAndPGeoCenter>>()
            //    .ForMember(dest=>dest.data.centerPoint,opt=>opt.MapFrom(x=>x.))
            
        }
    }
}
