using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Services;
using News.Domain.Entities;
using News.Persistence.UnitOfWorks;

namespace News.Persistence.Services
{
    public class CategoryService :IScoped, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NewsCategory>> GetAllCategory()
        => await _unitOfWork.GetReadRepository<NewsCategory>().GetAllAsync(c => !c.IsDeleted);

    }
}