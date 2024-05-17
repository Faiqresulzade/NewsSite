using News.Application.Bases.Classes.Exceptions;

namespace News.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseExceptions
    {
        public UserAlreadyExistException() : base("Belə bir istifadəçı artıq mövcuddur") { }
    }
}
