using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace News.Api.Bases.Interfaces
{
    internal interface ICreatable<Trequest> where Trequest : class, IRequest<Unit>
    {
        public Task<IActionResult> Create(Trequest request);
    }
}
