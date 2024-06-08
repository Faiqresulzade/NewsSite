using MediatR;
using News.Api.Bases.Classes;
using Microsoft.AspNetCore.Mvc;
using News.Api.Bases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Application.Features.NewsCategory.Command.DeleteCategory;
using News.Application.Features.NewsCategory.Command.UpdateCategory;
using News.Application.Features.NewsCategory.Queries.GetCategoryById;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]"), ApiController]
    public class NewsCategoryController : BaseController,
        IReadable, IRemoveable<DeleteCategoryCommandRequest>,
        IUpdateable<UpdateCategoryCommandRequest>, ICreatable<CreateCategoryCommandRequest>,
        IGetEntityById<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        public NewsCategoryController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
          => Ok(await mediator.Send(new GetAllCategoriesQueryRequest()));

        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryQueryRequest request)
          => Ok(await mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryCommandRequest request)
          => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => StatusCode(StatusCodes.Status201Created));

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdateCategoryCommandRequest request)
          => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommandRequest request)
          => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());

    }
}