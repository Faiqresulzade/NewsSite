namespace News.Application.Bases.Classes.Exceptions
{
    public abstract class BaseExceptions : ApplicationException
    {
        public BaseExceptions() { }

        public BaseExceptions(string message) : base(message) { }
    }
}
