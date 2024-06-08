using News.Application.Bases.Interfaces.DI;
using News.Domain.Entities;

namespace News.Application.Bases.Interfaces.Services
{
    public interface ICategoryService : IDependencyInjections
    {
        Task<IList<NewsCategory>> GetAllCategory();
    }
}
