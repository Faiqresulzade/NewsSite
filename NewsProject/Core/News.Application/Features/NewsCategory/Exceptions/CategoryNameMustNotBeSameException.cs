using News.Application.Bases.Classes.Exceptions;

namespace News.Application.Features.NewsCategory.Exceptions
{
    public sealed class CategoryNameMustNotBeSameException : BaseExceptions
    {
        public CategoryNameMustNotBeSameException() : base("Bu adda kateqoriya var! ") { }
    }
}
