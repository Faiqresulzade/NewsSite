using Microsoft.AspNetCore.Mvc;

namespace News.Api.Bases.Interfaces
{
    internal interface IReadable
    {
        public Task<IActionResult> GetAll();
    }
}
