namespace Checkr.Services.Abstract
{
    public interface IFileService
    {
        Task<string> SaveFileInFolderAsync(IFormFile file, string folder);

        void DeleteFileInFolder(string fileName, string folder);
    }
}
