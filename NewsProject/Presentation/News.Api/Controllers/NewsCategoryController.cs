using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Api.Bases.Classes;
using News.Api.Bases.Interfaces;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Application.Features.NewsCategory.Command.DeleteCategory;
using News.Application.Features.NewsCategory.Command.UpdateCategory;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]"), ApiController]
    public class NewsCategoryController : BaseController,
        IReadable, IRemoveable<DeleteCategoryCommandRequest>,
        IUpdateable<UpdateCategoryCommandRequest>, ICreatable<CreateCategoryCommandRequest>
    {
        public NewsCategoryController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
          => Ok(await mediator.Send(new GetAllCategoriesQueryRequest()));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
          => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
          => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategoryCommandRequest request)
          => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());

    }
}