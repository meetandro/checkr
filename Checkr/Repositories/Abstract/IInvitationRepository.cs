using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IInvitationRepository
    {
        Task<IEnumerable<Invitation>> GetAllReceivedInvitationsForUserAsync(string userId);

        Task<Invitation?> GetByIdAsync(int id);

        Task<Invitation?> DeleteAsync(int id);
    }
}
