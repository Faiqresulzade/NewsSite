using Microsoft.AspNetCore.Mvc;
using NewsEntity = News.Domain.Entities.News;
using MediatR;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;
using News.Api.Bases.Classes;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]"), ApiController]
    public class NewsController : BaseController
    {
        public NewsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await mediator.Send(new GetAllCategoriesQueryRequest()));

    }
}