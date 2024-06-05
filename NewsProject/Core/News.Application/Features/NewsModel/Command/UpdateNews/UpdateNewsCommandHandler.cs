using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Helpers;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Command.UpdateNews
{
    internal class UpdateNewsCommandHandler : UpdateCommandHandler, IRequestHandler<UpdateNewsCommandRequest, Unit>
    {
        public static event Func<UpdateNewsCommandRequest, IList<NewsEntity>, (bool, NewsEntity)>? OnNewsUpdate;
        public UpdateNewsCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<Unit> Handle(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            IList<NewsEntity> news = await unitOfWork.GetReadRepository<NewsEntity>().GetAllAsync(x => !x.IsDeleted);

            var result = OnNewsUpdate?.Invoke(request, news);

            //NewsEntity news = request;


            //xeber db-dan id gore tapilmalidir. event touple return etmelidir ,bir tapilan xeberi birdeki bool deyeri
            //burada implicity type castinge ehtiyac yoxdur.

            return default;
        }
    }
}
