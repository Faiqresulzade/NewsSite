using MediatR;
using System.ComponentModel;

namespace News.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("7l25x5f@code.edu.az")]
        public string Mail { get; set; }

        [DefaultValue("Faigrasul2002!")]
        public string Password { get; set; }
    }
}
