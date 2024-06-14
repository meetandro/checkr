using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsForBoardAsync(int boardId);

        Task<Box> AddTagsToBoxAsync(int boxId, ICollection<int> tagsIds);

        Task<Tag> GetTagByIdAsync(int id);

        Task<Tag> CreateTagAsync(TagDto tagDto);

        Task<Tag> UpdateTagAsync(int id, TagDto tagDto);

        Task<Tag> DeleteTagAsync(int id);
    }
}
