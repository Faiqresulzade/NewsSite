using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace News.Api.Bases.Interfaces
{
    public interface ICreatable<Trequest> where Trequest : class, IRequest
    {
        private protected Task<IActionResult> Create(Trequest request);
    }
}
