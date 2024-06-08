using Microsoft.AspNetCore.Http;

namespace News.Application.Utilities.Helpers
{
    public interface IFileHelper
    {
        bool CheckSize(IFormFile file, int size);
        void Delete(string fileName);
        bool IsImage(IFormFile file);
        bool IsPdf(IFormFile file);
        Task<string> Upload(IFormFile file);
    }
}