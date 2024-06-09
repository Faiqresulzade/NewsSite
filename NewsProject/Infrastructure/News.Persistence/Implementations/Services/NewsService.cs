using Microsoft.AspNetCore.Http;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Services.News;
using News.Application.Utilities.Helpers;
using NewsEntity = News.Domain.Entities.News;

namespace News.Persistence.Implementations.Services
{
    public class NewsService : IScoped, IReadCountİncrementable
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string _newsCookieKey = "NewsRead_";

        public NewsService(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

        public async Task IncrementReadCount(NewsEntity news, IUnitOfWork unitOfWork)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            string cookieKey = $"{_newsCookieKey}{news.Id}";
            string cookieValue = CookieHelper.GetCookie(httpContext, cookieKey);

            if (string.IsNullOrEmpty(cookieValue))
            {
                news.ReadCount++;
                CookieHelper.SetCookie(httpContext, cookieKey, "true", 1);

                await unitOfWork.GetWriteRepository<NewsEntity>().UpdateAsync(news);
            }
        }
    }
}