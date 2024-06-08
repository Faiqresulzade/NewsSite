using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Features.NewsCategory.Command.DeleteCategory;

namespace News.Api.Bases.Interfaces
{
    internal interface IRemoveable<Trequest> where Trequest : class, IRequest<Unit>
    {
        public Task<IActionResult> Delete([FromRoute] Trequest request);
    }
}
