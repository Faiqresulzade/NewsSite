using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Bases.Classes
{
    public abstract class CreateCommandHandler<T>
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly T factory;

        public CreateCommandHandler(IUnitOfWork unitOfWork, T factory)
        {
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }
    }
}
