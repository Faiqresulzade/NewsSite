using Microsoft.AspNetCore.Mvc;
using NewsEntity = News.Domain.Entities.News;
using MediatR;
using News.Application.Features.NewsCategory.Queries.GetAllCategories;
using News.Api.Bases.Classes;
using News.Api.Bases.Interfaces;
using News.Application.Features.NewsModel.Command.CreateNews;
using News.Application.Features.NewsModel.Queries.GetAllNews;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]"), ApiController]
    public class NewsController : BaseController, ICreatable<CreateNewsCommandRequest>
    {
        public NewsController(IMediator mediator, IHostEnvironment host) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(await mediator.Send(new GetAllNewsQueryRequest()));

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateNewsCommandRequest request)
        => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());
    }
}