using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Rules;

namespace News.Application.Features.NewsModel.Rules
{
    public class NewsRules : ITransient, INewsRules
    {
        public Domain.Entities.News EntityNotFound(Domain.Entities.News? category)
        {
            throw new NotImplementedException();
        }
    }
}
