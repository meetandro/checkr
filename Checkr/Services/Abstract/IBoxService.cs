using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IBoxService
    {
        Task<Box> GetBoxByIdAsync(int boxId);

        Task<Box> CreateBoxAsync(BoxDto boxDto);

        Task<Box> UpdateBoxAsync(int boxId, BoxDto boxDto);

        Task<Box> DeleteBoxAsync(int boxId);
    }
}
