using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();

        Tag GetTagById(int id);

        Tag AddTag(Tag tag);

        Tag UpdateTag(Tag label);

        Tag DeleteTag(int id);
    }
}
