using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IInvitationService
    {
        Task<IEnumerable<Invitation>> GetAllReceivedInvitationsForUserAsync(string userId);

        Task<Invitation?> CreateInvitationAsync(InvitationDto invitationDto);

        Task<Invitation> RespondToInvitationAsync(int invitationId, bool isAccepted);
    }
}
