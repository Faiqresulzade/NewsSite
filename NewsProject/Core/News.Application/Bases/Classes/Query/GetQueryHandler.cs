using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Domain.Comman;

namespace News.Application.Bases.Classes.Query
{
    public class GetQueryHandler
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public GetQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.mapper = mapper;
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
