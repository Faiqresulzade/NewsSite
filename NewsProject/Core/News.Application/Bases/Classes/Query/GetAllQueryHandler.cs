using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.AutoMapper;
using News.Domain.Comman;

namespace News.Application.Bases.Classes.Query
{
    /// <summary>
    /// Base class for query handlers responsible for retrieving all entities of a specific type, providing access to a unit of work and a mapper for object mapping.
    /// </summary>

    public class GetAllQueryHandler
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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