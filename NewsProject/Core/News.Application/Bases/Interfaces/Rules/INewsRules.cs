using News.Application.Bases.Interfaces.DI;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Bases.Interfaces.Rules
{
    public interface INewsRules : IBaseRule<NewsEntity>, IDependencyInjections
    {
    }
}
