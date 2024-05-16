using News.Application.Bases.Classes.Exceptions;

namespace News.Application.Features.NewsCategory.Exceptions
{
    public class CategoryNameMustNotBeSameException : BaseExceptions
    {
        public CategoryNameMustNotBeSameException() : base("Bu adda kateqoriya var! ") { }
    }
}
