using News.Domain.Entities;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Features.Auth.Command.Login;
using News.Application.Features.Auth.Command.Register;
using ServicesRegisterPlugin.Atributes;

namespace News.Application.Features.Auth.EventHandler
{

    [Transient()]
    public class AuthEventHandler 
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
