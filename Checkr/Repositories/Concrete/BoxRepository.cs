

using Checkr.Entities;
using Checkr.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class BoxRepository : IBoxRepository
    {
        private readonly ApplicationDbContext _context;

        public BoxRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Box> GetAllBoxes()
        {
            return _context.Boxes.ToList();
        }

        public Box GetBoxById(int id)
        {
            return _context.Boxes.Find(id);
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
            var box = _context.Boxes.Find(id);
            if (box != null)
            {
                _context.Boxes.Remove(box);
                _context.SaveChanges();
            }
            return box;
        }
    }
}

