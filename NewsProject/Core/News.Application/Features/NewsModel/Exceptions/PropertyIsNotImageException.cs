using News.Application.Bases.Classes.Exceptions;

namespace News.Application.Features.NewsModel.Exceptions
{
    public class PropertyIsNotImageException : BaseExceptions
    {
        public PropertyIsNotImageException() : base("Yüklənən fayl image formatında olmalıdır!") { }
    }
}
