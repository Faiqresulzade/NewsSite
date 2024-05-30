using News.Domain.Entities;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.Auth.Exceptions;
using News.Application.Bases.Classes.Rules;
using News.Application.Bases.Interfaces.Rules;

namespace News.Application.Features.Auth.Rules
{
    public class AuthRules : IAuthRules, ITransient
    {
        public void UserSholdNotBeExist(User? user)
           => EntityNotFound(user);

        public void EmailorPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword)
                throw new EmailorPasswordShouldNotBeInvalidException();
        }

        public  User? EntityNotFound(User? entity)
        {
            if (entity is not null)
                throw new UserAlreadyExistException();

            return default;
        }
    }
}
