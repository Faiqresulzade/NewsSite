using MediatR;
using News.Application.Bases.Classes.Command;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using NewsEntity = News.Domain.Entities.News;
using News.Application.Utilities.Helpers;

namespace News.Application.Features.NewsModel.Command.UpdateNews
{
    internal class UpdateNewsCommandHandler : UpdateCommandHandler<UpdateNewsCommandRequest, NewsEntity>, IRequestHandler<UpdateNewsCommandRequest, Unit>
    {
        /// <summary>
        /// Event triggered during the news update process.
        /// </summary>
        public static event Func<UpdateNewsCommandRequest, IList<NewsEntity>, (bool isImageOk, NewsEntity newsEntity)>? OnNewsUpdate;

        public UpdateNewsCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<Unit> Handle(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            IList<NewsEntity> news = await unitOfWork.GetReadRepository<NewsEntity>().GetAllAsync(x => !x.IsDeleted);
            var result = OnNewsUpdate?.Invoke(request, news);

            if (result == null)
                throw new InvalidOperationException("News update event did not return a valid result.");

            var (isImageOk, newsEntity) = result.Value;

            if (isImageOk)
                await UpdateImage(newsEntity, request);

            NewsEntity updatedEntity = UpdateEntityProperties(request, newsEntity);
            await unitOfWork.GetWriteRepository<NewsEntity>().UpdateAsync(updatedEntity);

            return Unit.Value;
        }

        /// <summary>
        /// Updates the image of the news entity.
        /// </summary>
        /// <param name="newsEntity">The news entity to update.</param>
        /// <param name="request">The update news command request.</param>
        /// <returns>A task that represents the completion of the image update operation.</returns>
        private async Task UpdateImage(NewsEntity newsEntity, UpdateNewsCommandRequest request)
        {
            FileHelper.Instance.Delete(newsEntity.ImagePath);
            newsEntity.ImagePath = await FileHelper.Instance.Upload(request.NewsImage);
        }

        /// <summary>
        /// Updates the properties of the news entity.
        /// </summary>
        /// <param name="request">The update news command request.</param>
        /// <param name="entity">The news entity to update.</param>
        /// <returns>The updated news entity.</returns>
        private protected override NewsEntity UpdateEntityProperties(UpdateNewsCommandRequest request, NewsEntity entity)
        {
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.AuthorName = request.AuthorName;
            entity.CategoryId = request.CategoryId;

            return entity;
        }
    }
}