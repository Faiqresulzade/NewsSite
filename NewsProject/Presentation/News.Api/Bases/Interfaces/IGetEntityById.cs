using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Features.NewsModel.Queries.GetNewsById;

namespace News.Api.Bases.Interfaces
{
    internal interface IGetEntityById<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
    {
        public Task<IActionResult> GetById([FromRoute] TRequest request);
    }
}
