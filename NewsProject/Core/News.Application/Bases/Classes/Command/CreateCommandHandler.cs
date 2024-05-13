using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Bases.Classes.Command
{
    /// <summary>
    /// Base class for command handlers responsible for creating entities,
    /// providing access to a unit of work and a factory for entity creation.
    /// </summary>

    public abstract class CreateCommandHandler<Tfactory>
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly Tfactory factory;

        public CreateCommandHandler(in IUnitOfWork unitOfWork, Tfactory factory)
        {
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }
    }
}