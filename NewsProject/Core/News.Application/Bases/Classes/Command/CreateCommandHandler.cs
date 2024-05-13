using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Bases.Classes.Command
{
    public abstract class CreateCommandHandler<Tfactory>
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly Tfactory factory;

        public CreateCommandHandler(in IUnitOfWork unitOfWork, in Tfactory factory)
        {
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }
    }
}