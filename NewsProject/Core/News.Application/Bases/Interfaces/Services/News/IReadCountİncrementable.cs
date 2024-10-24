using News.Application.Abstraction.Interfaces.UnitOfWorks;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Bases.Interfaces.Services.News
{
    public interface IReadCountİncrementable 
    {
        Task IncrementReadCount(NewsEntity news, IUnitOfWork unitOfWork);
    }
}
