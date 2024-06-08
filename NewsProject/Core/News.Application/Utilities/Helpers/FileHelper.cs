using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using News.Application.Bases.Classes.Singleton;
using Microsoft.Extensions.Hosting;

namespace News.Application.Utilities.Helpers
{
    public class FileHelper : SingletonBase<FileHelper>, IFileHelper
    {
        private static IHostEnvironment _hostingEnvironment;

        public static void Configure(IHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        public async Task<string> Upload(IFormFile file)
        {
            string fileName = $"{Guid.NewGuid()}_{file.FileName}";

            string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "assets", "media", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine("wwwroot", "assets", "media", fileName);
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
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