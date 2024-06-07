using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class LabelRepository(ApplicationDbContext context) : ILabelRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<Label> GetAllLabels()
        {
            var labels = _context.Labels
                .Include("Boxes")
                .ToList();
            return labels;
        }

        public Label GetLabelById(int id)
        {
            var label = _context.Labels
                .Include("Boxes")
                .FirstOrDefault(l => l.Id == id);
            return label;
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
            var label = GetLabelById(id);
            _context.Labels.Remove(label);
            _context.SaveChanges();
            return label;
        }
    }
}
