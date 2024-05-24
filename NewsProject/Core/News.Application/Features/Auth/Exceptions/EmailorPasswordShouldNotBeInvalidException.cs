using News.Application.Bases.Classes.Exceptions;

namespace News.Application.Features.Auth.Exceptions
{
    public class EmailorPasswordShouldNotBeInvalidException : BaseExceptions
    {
        public EmailorPasswordShouldNotBeInvalidException() : base("Email və ya Password yalnışdır!") { }
    }
}
