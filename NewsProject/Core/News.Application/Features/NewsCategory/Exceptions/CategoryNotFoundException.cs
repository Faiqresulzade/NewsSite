using News.Application.Bases.Classes.Exceptions;

namespace News.Application.Features.NewsCategory.Exceptions
{
    public class CategoryNotFoundException : BaseExceptions
    {
        public CategoryNotFoundException() : base("Belə xəbər kateqoriyası mövcud deyil! ") { }
    }
}
