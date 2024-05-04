using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Bases.Classes
{
    public class CreateCommandHandler<T>
    {
       private protected IUnitOfWork unitOfWork;
       private protected readonly T factory;

        public CreateCommandHandler(IUnitOfWork unitOfWork, T factory)
        {
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }
    }
}
