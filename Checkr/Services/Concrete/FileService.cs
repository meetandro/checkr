using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class FileService(IWebHostEnvironment environment) : IFileService
    {
        private readonly IWebHostEnvironment _environment = environment;

        public async Task<string> SaveFileInFolderAsync(IFormFile file, string folder)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = $"Checkr-{DateTime.UtcNow:yyyyMMddHHmmssfff}{fileExtension}";

            string fullPath = Path.Combine(_environment.WebRootPath, folder, fileName);
            using (var stream = File.Create(fullPath))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public void DeleteFileInFolder(string fileName, string folder)
        {
            string fullPath = Path.Combine(_environment.WebRootPath, folder, fileName);
            File.Delete(fullPath);
        }
    }
}
