using MediatR;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Features.NewsCategory.Rules;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    /// <summary>
    /// Handler for updating a news category, responsible for processing the update request and interacting with the data layer.
    /// </summary>

    internal class UpdateCategoryCommandHandler : UpdateCommandHandler, IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly NewsCategoryRules _rules;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, NewsCategoryRules rules)
        : base(unitOfWork)
        {
            _rules = rules;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            IWriteRepository<Category> writeRepository = unitOfWork.GetWriteRepository<Category>();

            _rules.FindCategory(categories, request.Id);
            await _rules.CategoryNameMustNotBeSame(categories, request.Name);
            if (await _rules.RestoreDeletedCategoryAsync(categories, request.Name, unitOfWork, writeRepository))
                return default;

            // Previously, a mapper was used to convert the request to a Category. 
            // Now, we use an implicit conversion.
            Category mapedData = request;

            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(mapedData);

            return default;
        }
    }
}