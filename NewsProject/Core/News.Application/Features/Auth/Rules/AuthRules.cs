using News.Domain.Entities;
using News.Application.Bases.Classes.Rules;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.Auth.Exceptions;

namespace News.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules, ITransient
    {
        public void UserSholdNotBeExist(User? user)
        {
            if (user is not null)
                throw new UserAlreadyExistException();
        }

        public void EmailorPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword)
                throw new EmailorPasswordShouldNotBeInvalidException();
        }
    }
}
