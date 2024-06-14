using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IBoxRepository
    {
        Task<Box?> GetByIdAsync(int id);

        Task<Box> CreateAsync(Box box);

        Task<Box> UpdateAsync(Box box);

        Task<Box?> DeleteAsync(int id);
    }
}
