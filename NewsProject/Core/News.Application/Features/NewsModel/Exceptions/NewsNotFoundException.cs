using News.Application.Bases.Classes.Exceptions;

namespace News.Application.Features.NewsModel.Exceptions
{
    public class NewsNotFoundException : BaseExceptions
    {
        public NewsNotFoundException() : base("Belə xəbər mövcud deyil! ") { }
    }
}
