using Microsoft.AspNetCore.Mvc;
using NewsEntity = News.Domain.Entities.News;
using MediatR;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllCategoriesQueryRequest()));

    }
}