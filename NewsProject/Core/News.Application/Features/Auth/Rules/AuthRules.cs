using News.Domain.Entities;
using News.Application.Bases.Classes.Rules;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.Auth.Exceptions;
using News.Application.Bases.Interfaces.Rules;

namespace News.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules<User>, IAuthRules, ITransient
    {
        public void UserSholdNotBeExist(User? user)
         => base.EntityNotFound(user);

        public void EmailorPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword)
                throw new EmailorPasswordShouldNotBeInvalidException();
        }
    }
}