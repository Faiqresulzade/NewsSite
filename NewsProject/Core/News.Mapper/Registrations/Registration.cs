using Microsoft.Extensions.DependencyInjection;
using News.Application.Abstraction.Interfaces.AutoMapper;
using NewsMapper = News.Mapper.AutoMapper.Mapper;

namespace News.Mapper.Registrations
{
    public static class Registration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            //services.AddSingleton<IMapper, NewsMapper>();
        }
    }
}
