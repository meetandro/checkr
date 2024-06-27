using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class InvitationService(
        IInvitationRepository invitationRepository,
        IBoardRepository boardRepository,
        IUserService userService) : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository = invitationRepository;
        private readonly IBoardRepository _boardRepository = boardRepository;
        private readonly IUserService _userService = userService;

        public async Task<IEnumerable<Invitation>> GetAllReceivedInvitationsForUserAsync(string userId)
        {
            return await _invitationRepository.GetAllReceivedInvitationsForUserAsync(userId);
        }

        public async Task<Invitation?> CreateInvitationAsync(InvitationDto invitationDto)
        {
            var board = await _boardRepository.GetByIdAsync(invitationDto.BoardId) ?? throw new EntityNotFoundException();

            var sender = await _userService.GetUserByIdAsync(invitationDto.SenderId);

            var recipient = await _userService.GetUserByIdAsync(invitationDto.RecipientId);

            if (board.Users.Contains(recipient) || board.Invitations.Any(i => i.RecipientId == recipient.Id))
            {
                return null;
            }

            var invitation = new Invitation
            {
                Board = board,
                Sender = sender,
                Recipient = recipient,
                CreatedAt = DateTime.UtcNow
            };

            board.Invitations.Add(invitation);

            sender.SentInvitations.Add(invitation);
            recipient.ReceivedInvitations.Add(invitation);

            await _boardRepository.UpdateAsync(board);

            return invitation;
        }

        public async Task<Invitation> RespondToInvitationAsync(int invitationId, bool isAccepted)
        {
            var invitation = await _invitationRepository.GetByIdAsync(invitationId) ?? throw new EntityNotFoundException();

            var board = await _boardRepository.GetByIdAsync(invitation.BoardId) ?? throw new EntityNotFoundException();

            var recipient = await _userService.GetUserByIdAsync(invitation.RecipientId);

            if (isAccepted)
            {
                board.Users.Add(recipient);
                invitation.IsAccepted = true;
            }
            else
            {
                await _invitationRepository.DeleteAsync(invitationId);
            }

            await _boardRepository.UpdateAsync(board);

            return invitation;
        }
    }
}
