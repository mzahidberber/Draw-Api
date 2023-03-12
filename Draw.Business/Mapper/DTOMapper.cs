using AutoMapper;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete;

namespace Draw.Business.Mapper
{
    internal class DTOMapper:Profile
    {
        public DTOMapper()
        {
            CreateMap<ColorDTO, Color>().ReverseMap();
            CreateMap<LayerDTO, Layer>().ReverseMap();
            CreateMap<ElementDTO, Element>().ReverseMap();
            CreateMap<DrawBoxDTO, DrawBox>().ReverseMap();
            CreateMap<PointDTO, Point>().ReverseMap();
            CreateMap<ColorDTO, Color>().ReverseMap();
            CreateMap<PenDTO, Pen>().ReverseMap();
            CreateMap<PenStyleDTO, PenStyle>().ReverseMap();
            CreateMap<ElementTypeDTO, ElementType>().ReverseMap();
            CreateMap<PointTypeDTO, PointType>().ReverseMap();
            CreateMap<SSAngleDTO, SSAngle>().ReverseMap();
            CreateMap<RadiusDTO, Radius>().ReverseMap();
        }
    }
}
