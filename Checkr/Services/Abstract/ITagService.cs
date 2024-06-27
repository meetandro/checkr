using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface ITagService
    {
        Task<Tag> GetTagByIdAsync(int id);

        Task<Tag> CreateTagAsync(TagDto tagDto);

        Task<Tag> UpdateTagAsync(int id, TagDto tagDto);

        Task<Tag> DeleteTagAsync(int id);
    }
}
