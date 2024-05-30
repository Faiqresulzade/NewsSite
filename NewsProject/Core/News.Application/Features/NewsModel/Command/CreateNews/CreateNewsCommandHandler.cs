using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Factories;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Command.CreateNews
{
    public class CreateNewsCommandHandler : CreateCommandHandler<INewsFactory>, IRequestHandler<CreateNewsCommandRequest, Unit>
    {
        public CreateNewsCommandHandler(IUnitOfWork unitOfWork, INewsFactory factory) : base(unitOfWork, factory) { }


        public async Task<Unit> Handle(CreateNewsCommandRequest request, CancellationToken cancellationToken)
        {

            await base.AddAsync<NewsEntity, INewsFactory, CreateNewsCommandRequest>(unitOfWork, factory, request);
           
            return default;
        }
    }
}
