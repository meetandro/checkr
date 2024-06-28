using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    [Authorize]
    public class InvitationsController(
        IInvitationService invitationService,
        IUserService userService) : Controller
    {
        private readonly IInvitationService _invitationService = invitationService;
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = await _userService.GetUserIdAsync(User);

            var invitations = await _invitationService.GetAllReceivedInvitationsForUserAsync(userId);

            return View(invitations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvitationDto invitationDto)
        {
            if (!ModelState.IsValid)
            {
                return View(invitationDto);
            }

            var senderId = await _userService.GetUserIdAsync(User);
            invitationDto.SenderId = senderId;

            var recipientId = await _userService.GetUserIdByEmailAsync(invitationDto.RecipientEmail);
            if (recipientId is null)
            {
                ModelState.AddModelError("RecipientEmail", "User doesn't exist.");
                return View(invitationDto);
            }
            invitationDto.RecipientId = recipientId;

            var invitation = await _invitationService.CreateInvitationAsync(invitationDto);
            if (invitation is null)
            {
                ModelState.AddModelError("RecipientEmail", "User is already invited or is a member.");
                return View(invitationDto);
            }

            return RedirectToAction("Users", "Boards", new { id = invitationDto.BoardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RespondToInvitation(int id, bool isAccepted)
        {
            await _invitationService.RespondToInvitationAsync(id, isAccepted);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _invitationService.DeleteInvitationAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
