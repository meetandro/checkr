namespace Checkr.Services.Abstract
{
    public interface IFileService
    {
        string SaveFileInFolder(IFormFile file, string folder);

        void DeleteFileInFolder(string fileName, string folder);
    }
}
