using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsCategoryController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
             Ok(await _mediator.Send(new GetAllCategoriesQueryRequest()));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
