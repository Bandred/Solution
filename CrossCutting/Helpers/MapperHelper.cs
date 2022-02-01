using AutoMapper;

namespace CrossCutting.Helpers
{
    public abstract class MapperHelper
    {
        protected static IMapper staticMapper;

        public static TDestination Map<TDestination, TSource>(TSource entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            var _mapper = config.CreateMapper();

            return _mapper.Map<TDestination>(entity);
        }
    }
}
