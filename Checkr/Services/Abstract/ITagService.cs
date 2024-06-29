using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface ITagService
    {
        Task<Tag> GetTagByIdAsync(int tagId);

        Task<Tag> CreateTagAsync(TagDto tagDto);

        Task<Tag> UpdateTagAsync(int tagId, TagDto tagDto);

        Task<Tag> DeleteTagAsync(int tagId);
    }
}
