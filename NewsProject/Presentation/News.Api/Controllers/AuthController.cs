﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Api.Bases.Classes;
using News.Application.Features.Auth.Command.Login;
using News.Application.Features.Auth.Command.Register;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediatr) : base(mediatr) { }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}