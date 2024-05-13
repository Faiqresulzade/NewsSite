using AutoMapper;
using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using INewsMapper = News.Application.Abstraction.Interfaces.AutoMapper.IMapper;
using NewsMapper = News.Application.AutoMapper.Mapper;

namespace News.Application.Bases.Classes.Command
{
    internal abstract class UpdateCommandHandler
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly INewsMapper mapper;

        public UpdateCommandHandler(in IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.mapper = NewsMapper.Instance;
        }
    }
}
