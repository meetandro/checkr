using Checkr.Data;
using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class InvitationRepository(ApplicationDbContext context) : IInvitationRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Invitation>> GetAllReceivedInvitationsForUserAsync(string userId)
        {
            return await _context.Invitations
                .Where(i => i.RecipientId == userId)
                .Include(i => i.Sender)
                .Include(i => i.Recipient)
                .Include(i => i.Board)
                .ToListAsync();
        }

        public async Task<Invitation?> GetByIdAsync(int id)
        {
            return await _context.Invitations
                .Include(i => i.Sender)
                .Include(i => i.Recipient)
                .Include(i => i.Board)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Invitation?> DeleteAsync(int id)
        {
            var invitation = await GetByIdAsync(id);
            if (invitation is not null)
            {
                _context.Invitations.Remove(invitation);
                await _context.SaveChangesAsync();
            }
            return invitation;
        }
    }
}
