using AutoMapper;

namespace Draw.Web.Mapper
{
    internal static class WebObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<DTOMapper>(); });
            return config.CreateMapper();

        });

        public static IMapper Mapper => lazy.Value;
    }
}
