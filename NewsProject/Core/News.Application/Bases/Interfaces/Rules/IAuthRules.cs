using News.Application.Bases.Interfaces.DI;
using News.Domain.Entities;

namespace News.Application.Bases.Interfaces.Rules
{
    public interface IAuthRules : IDependencyInjections, IBaseRule<User>
    {
        void UserSholdNotBeExist(User? user);
        void EmailorPasswordShouldNotBeInvalid(User? user, bool checkPassword);
    }
}
