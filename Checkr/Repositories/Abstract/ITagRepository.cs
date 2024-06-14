using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllTagsForBoardAsync(int boardId);

        Task<IEnumerable<Tag>> GetByIdsAsync(ICollection<int> ids);

        Task<Tag?> GetByIdAsync(int id);

        Task<Tag> CreateAsync(Tag tag);

        Task<Tag> UpdateAsync(Tag tag);

        Task<Tag?> DeleteAsync(int id);
    }
}
