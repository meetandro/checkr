
using Checkr.Entities;
using Checkr.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class LabelRepository : ILabelRepository
    {
        private readonly ApplicationDbContext _context;

        public LabelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Label> GetAllLabels()
        {
            return _context.Labels.ToList();
        }

        public Label GetLabelById(int id)
        {
            return _context.Labels.Find(id);
        }

        public Label AddLabel(Label label)
        {
            _context.Labels.Add(label);
            _context.SaveChanges();
            return label;
        }

        public Label UpdateLabel(Label label)
        {
            _context.Labels.Update(label);
            _context.SaveChanges();
            return label;
        }

        public Label DeleteLabel(int id)
        {
            var label = _context.Labels.Find(id);
            if (label != null)
            {
                _context.Labels.Remove(label);
                _context.SaveChanges();
            }
            return label;
        }
    }
}

