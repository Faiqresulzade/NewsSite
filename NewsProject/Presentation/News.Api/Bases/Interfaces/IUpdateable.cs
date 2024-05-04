using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace News.Api.Bases.Interfaces
{
    public interface IUpdateable<Trequest> where Trequest : class, IRequest
    {
        private protected Task<IActionResult> Update(Trequest request);
    }
}
