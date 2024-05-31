using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using News.Application.Bases.Classes.Singleton;
using News.Application.Bases.Interfaces.Helpers;

namespace News.Application.Utilities.Helpers
{
    public class FileHelper : SingletonBase<FileHelper>, IFileHelper
    {
        public async Task<string> Upload(IFormFile file, string webRootPath)
        {
            string fileName = $"{Guid.NewGuid()}_{file.FileName}";

            string path = Path.Combine(webRootPath, "assets/media", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                await file.CopyToAsync(fileStream);

            return fileName;
        }

        public void Delete(string webRootPath, string fileName)
        {
            var path = Path.Combine(webRootPath, "assets/media", fileName);

            if (File.Exists(path))
                File.Delete(path);
        }

        public bool IsImage(IFormFile file) => file.ContentType.Contains("image/");

        public bool CheckSize(IFormFile file, int size)
        {
            return true;
        }

        public bool IsPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string extension = Path.GetExtension(fileName);

            return extension == ".pdf";
        }
    }
}