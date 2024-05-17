using News.Application.Bases.Classes.Rules;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.Auth.Exceptions;
using News.Domain.Entities;

namespace News.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules, ITransient
    {
        public Task UserSholdNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();

            return Task.CompletedTask;
        }
    }
}
