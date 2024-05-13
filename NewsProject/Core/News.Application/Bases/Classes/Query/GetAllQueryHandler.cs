
using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Singleton;
using News.Application.Bases.Interfaces.Singleton;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;
using News.Domain.Comman;

namespace News.Application.Bases.Classes.Query
{
    public class GetAllQueryHandler
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            //this.mapper = SingletonBase<Mapper>;
        }

        private protected virtual async Task<IList<TResponse>> GetAllEntity<TResponse, Tentity>()
           where Tentity : EntityBase, IEntityBase, new()
        {
            var categories = await unitOfWork.GetReadRepository<Tentity>().GetAllAsync(n => !n.IsDeleted);

            var mapedData = mapper.Map<TResponse, Tentity>(categories);
            return mapedData;
        }
    }
}
