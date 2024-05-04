using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Features.NewsCategory.Command.DeleteCategory;

namespace News.Api.Bases.Interfaces
{
    public interface IRemoveable<Trequest> where Trequest : class, IRequest
    {
        private protected Task<IActionResult> Delete(Trequest request);
    }
}
