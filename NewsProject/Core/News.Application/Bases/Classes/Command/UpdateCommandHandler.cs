using News.Application.Abstraction.Interfaces.UnitOfWorks;
using INewsMapper = News.Application.Abstraction.Interfaces.AutoMapper.IMapper;
using NewsMapper = News.Application.AutoMapper.Mapper;

namespace News.Application.Bases.Classes.Command
{
    /// <summary>
    /// Base class for command handlers responsible for updating entities, providing access to a unit of work and a mapper for object mapping.
    /// </summary>

    internal abstract class UpdateCommandHandler<TRequest, TEntity>
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly INewsMapper mapper;

        public UpdateCommandHandler(in IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = NewsMapper.Instance;
        }

        private protected abstract TEntity UpdateEntityProperties(TRequest request, TEntity entity);
    }
}
