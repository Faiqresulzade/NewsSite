
using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Bases.Classes
{
    public abstract class DeleteCommandHandler
    {
        private protected readonly IUnitOfWork unitOfWork;

        public DeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
