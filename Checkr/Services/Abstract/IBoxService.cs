using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IBoxService
    {
        Task<Box> GetBoxByIdAsync(int id);

        Task<Box> CreateBoxAsync(BoxDto boxDto);

        Task<Box> UpdateBoxAsync(int boxId, BoxDto boxDto);

        Task<Box> DeleteBoxAsync(int id);
    }
}
