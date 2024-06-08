using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class TagRepository(ApplicationDbContext context) : ITagRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<Tag> GetAllTags()
        {
            var tags = _context.Tags
                .Include(t => t.Boxes)
                .ToList();
            return tags;
        }

        public Tag GetTagById(int id)
        {
            var tag = _context.Tags
                .Include(t => t.Boxes)
                .FirstOrDefault(l => l.Id == id);
            return tag;
        }

        public Tag AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag;
        }

        public Tag UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            _context.SaveChanges();
            return tag;
        }

        public Tag DeleteTag(int id)
        {
            var tag = GetTagById(id);
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return tag;
        }
    }
}
