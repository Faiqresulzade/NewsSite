using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Api.Bases.Classes;
using News.Api.Bases.Interfaces;
using News.Application.Features.Auth.Command.Register;

namespace News.Api.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediatr) : base(mediatr) { }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
