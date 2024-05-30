using Microsoft.AspNetCore.Http;
using News.Application.Bases.Interfaces.Singleton;

namespace News.Application.Bases.Interfaces.Helpers
{
    public interface IFileHelper : ISingletonBase<IFileHelper>
    {
        Task<string> Upload(IFormFile file, string webRootPath);
        void Delete(string webRootPath, string fileName);
        bool IsImage(IFormFile file);
        bool CheckSize(IFormFile file, int size);
        bool IsPdf(IFormFile file);
    }
}
