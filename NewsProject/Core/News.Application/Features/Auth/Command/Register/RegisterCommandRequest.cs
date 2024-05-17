using MediatR;
using News.Domain.Entities;

namespace News.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public static implicit operator User(RegisterCommandRequest request)
        {
            return new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                UserName = request.Email,
                SecurityStamp = Guid.NewGuid().ToString()

            };
        }
    }
}