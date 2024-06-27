using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class TagRepository(ApplicationDbContext context) : ITagRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Tag>> GetByIdsAsync(ICollection<int> ids)
        {
            return await _context.Tags
                .Where(t => ids.Contains(t.Id))
                .Include(t => t.Board)
                .Include(t => t.Boxes)
                .ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _context.Tags
                .Include(t => t.Board)
                .Include(t => t.Boxes)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(int id)
        {
            var tag = await GetByIdAsync(id);
            if (tag is not null)
            {
                foreach (var box in tag.Boxes)
                {
                    box.Tags.Remove(tag);
                }
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
            return tag;
        }
    }
}
