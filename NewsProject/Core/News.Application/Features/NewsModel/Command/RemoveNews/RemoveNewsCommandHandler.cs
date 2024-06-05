using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Rules;
using News.Domain.Comman;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Command.RemoveNews
{
    internal class RemoveNewsCommandHandler : DeleteCommandHandler, IRequestHandler<RemoveNewsCommandRequest, Unit>
    {
        public RemoveNewsCommandHandler(IUnitOfWork unitOfWork, INewsCategoryRules rules) : base(unitOfWork, (IBaseRule<EntityBase>)rules) { }

        public async Task<Unit> Handle(RemoveNewsCommandRequest request, CancellationToken cancellationToken)
        => await base.Delete<NewsEntity>(request.Id);
    }
}
