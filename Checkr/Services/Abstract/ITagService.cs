using Checkr.Entities;
using Checkr.Models;
using System.Collections.Generic;

public interface ITagService
{
    Tag AddTag(TagDto tagDto);
    Tag UpdateTag(TagDto tagDto);
    void DeleteTag(int id);
    void AddTagToBox(int tagId, int boxId);
    void RemoveTagFromBox(int tagId, int boxId);
    List<Tag> GetAllTagsForBox(int boxId);
}
