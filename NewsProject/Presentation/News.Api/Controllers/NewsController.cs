using MediatR;
using News.Api.Bases.Classes;
using Microsoft.AspNetCore.Mvc;
using News.Api.Bases.Interfaces;
using News.Application.Features.NewsModel.Command.CreateNews;
using News.Application.Features.NewsModel.Queries.GetAllNews;
using News.Application.Features.NewsModel.Queries.GetNewsById;
using News.Application.Features.NewsModel.Command.RemoveNews;
using News.Application.Features.NewsModel.Command.UpdateNews;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]"), ApiController]
    public class NewsController : BaseController, ICreatable<CreateNewsCommandRequest>,
        IGetEntityById<GetNewsByIdQueryRequest, GetNewsByIdQueryResponse>,
        IRemoveable<RemoveNewsCommandRequest>, IUpdateable<UpdateNewsCommandRequest>, IReadable
    {
        public NewsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(await mediator.Send(new GetAllNewsQueryRequest()));

        //categoryname is null
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetNewsByIdQueryRequest request)
        {
            var a = await mediator.Send(request);
            return Ok(a);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateNewsCommandRequest request)
        => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());

        [HttpPost("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveNewsCommandRequest request)
        => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());

        [HttpPost("{Id}")]
        public async Task<IActionResult> Update(UpdateNewsCommandRequest request)
         => await ExecuteCommand<IActionResult>(() => mediator.Send(request), () => Ok());
    }
}