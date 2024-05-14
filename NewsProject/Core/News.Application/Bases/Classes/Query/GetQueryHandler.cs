using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.AutoMapper;
using News.Domain.Comman;

namespace News.Application.Bases.Classes.Query
{
    /// <summary>
    /// Base class for query handlers responsible for retrieving a single entity by its ID, providing access to a unit of work and a mapper for object mapping.
    /// </summary>

    public class GetQueryHandler
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public GetQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.mapper = Mapper.Instance;
        }

        private protected virtual async Task<TResponse> GetEntity<TResponse, Tentity>(int id)
         where Tentity : EntityBase, IEntityBase, new()
        {
            var category = await unitOfWork.GetReadRepository<Tentity>().GetAsync(n => !n.IsDeleted && n.Id == id);

            var mapedData = mapper.Map<TResponse, Tentity>(category);
            return mapedData;
        }
    }
}
