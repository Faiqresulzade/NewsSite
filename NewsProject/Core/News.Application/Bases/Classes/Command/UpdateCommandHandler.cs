using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Bases.Classes.Command
{
    internal abstract class UpdateCommandHandler
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public UpdateCommandHandler(in IUnitOfWork unitOfWork,in IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
