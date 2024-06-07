using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class BoxRepository(ApplicationDbContext context) : IBoxRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<Box> GetAllBoxes()
        {
            var boxes = _context.Boxes
                .Include("Labels")
                .Include("Cards")
                .ToList();
            return boxes;
        }

        public Box GetBoxById(int id)
        {
            var box = _context.Boxes
                .Include("Labels")
                .Include("Cards")
                .FirstOrDefault(b => b.Id == id);
            return box;
        }

        public Box AddBox(Box box)
        {
            _context.Boxes.Add(box);
            _context.SaveChanges();
            return box;
        }

        public Box UpdateBox(Box box)
        {
            _context.Boxes.Update(box);
            _context.SaveChanges();
            return box;
        }

        public Box DeleteBox(int id)
        {
            var box = GetBoxById(id);
            _context.Boxes.Remove(box);
            _context.SaveChanges();
            return box;
        }
    }
}
