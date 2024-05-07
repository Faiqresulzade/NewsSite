using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace News.Api.Bases.Interfaces
{
    internal interface IUpdateable<Trequest> where Trequest : class, IRequest
    {
        public Task<IActionResult> Update(Trequest request);
    }
}
