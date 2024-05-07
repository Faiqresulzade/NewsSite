using Microsoft.Extensions.DependencyInjection;
using News.Application.Abstraction.Interfaces.AutoMapper;
using NewsMapper = News.Mapper.AutoMapper.Mapper;

namespace News.Mapper.Registrations
{
    internal static class Registration
    {
        internal static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, NewsMapper>();
        }
    }
}
