using Microsoft.AspNetCore.Mvc;

namespace News.Api.Bases.Interfaces
{
    public interface IReadable
    {
        private protected Task<IActionResult> GetAll();
    }
}
