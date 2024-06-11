using Checkr.Entities;
using Checkr.Models;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class TagService : ITagService
{
    private readonly ApplicationDbContext _context;

    public TagService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Tag AddTag(TagDto tagDto)
    {
        var tag = new Tag { TagName = tagDto.TagName, TagHex = tagDto.TagHex };
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public Tag UpdateTag(TagDto tagDto)
    {
        var tag = _context.Tags.Find(tagDto.Id);
        if (tag != null)
        {
            tag.TagName = tagDto.TagName;
            tag.TagHex = tagDto.TagHex;
            _context.Tags.Update(tag);
            _context.SaveChanges();
        }
        return tag;
    }

    public void DeleteTag(int id)
    {
        var tag = _context.Tags.Find(id);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }

    public void AddTagToBox(int tagId, int boxId)
    {
        var box = _context.Boxes.Include(b => b.Tags).FirstOrDefault(b => b.Id == boxId);
        var tag = _context.Tags.Find(tagId);

        if (box != null && tag != null && !box.Tags.Contains(tag))
        {
            box.Tags.Add(tag);
            _context.SaveChanges();
        }
    }

    public void RemoveTagFromBox(int tagId, int boxId)
    {
        var box = _context.Boxes.Include(b => b.Tags).FirstOrDefault(b => b.Id == boxId);
        var tag = _context.Tags.Find(tagId);

        if (box != null && tag != null && box.Tags.Contains(tag))
        {
            box.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }

    public List<Tag> GetAllTagsForBox(int boxId)
    {
        var box = _context.Boxes.Include(b => b.Tags).FirstOrDefault(b => b.Id == boxId);
        return box?.Tags.ToList() ?? new List<Tag>();
    }
}