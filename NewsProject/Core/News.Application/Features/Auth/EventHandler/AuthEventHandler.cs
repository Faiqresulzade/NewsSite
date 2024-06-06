using News.Domain.Entities;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Features.Auth.Command.Login;
using News.Application.Features.Auth.Command.Register;
using News.Application.Bases.Interfaces.DI;

namespace News.Application.Features.Auth.EventHandler
{
    public class AuthEventHandler : ITransient
    {
        private readonly IAuthRules _authRules;

        public AuthEventHandler(IAuthRules authRules)
        => _authRules = authRules;

        public void SubscribeToEvents()
        {
            LoginCommandHandler.OnUserLogin += OnUserLogin;
            RegisterCommandHandler.OnUserRegister += OnUserRegister;
        }

        private void OnUserRegister(User user)
        {
            _authRules.UserSholdNotBeExist(user);
        }

        private void OnUserLogin(User user, bool isvalidPassword)
        {
            _authRules.EmailorPasswordShouldNotBeInvalid(user, isvalidPassword);
        }

        private void UnSubscribeToEvents()
        {
            LoginCommandHandler.OnUserLogin -= OnUserLogin;
            RegisterCommandHandler.OnUserRegister -= OnUserRegister;

        }

        ~AuthEventHandler()
        {
            UnSubscribeToEvents();
        }
    }
}
