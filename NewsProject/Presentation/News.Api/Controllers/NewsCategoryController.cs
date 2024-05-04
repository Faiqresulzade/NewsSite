using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Api.Bases.Interfaces;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Application.Features.NewsCategory.Command.DeleteCategory;
using News.Application.Features.NewsCategory.Command.UpdateCategory;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsCategoryController : ControllerBase,
        IReadable, IRemoveable<DeleteCategoryCommandRequest>,
        IUpdateable<UpdateCategoryCommandRequest>, ICreatable<CreateCategoryCommandRequest>
    {
        private readonly IMediator _mediator;

        public NewsCategoryController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllCategoriesQueryRequest()));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
            => await ExecuteCommand(() => _mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
            => await ExecuteCommand(() => _mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategoryCommandRequest request)
            => await ExecuteCommand(() => _mediator.Send(request));

        private async Task<IActionResult> ExecuteCommand(Action action)
        {
            action?.Invoke();
            return Ok();
        }
    }
}