using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    [Authorize]
    public class MessagesController(IMessageService messageService, IUserService userService) : Controller
    {
        private readonly IMessageService _messageService = messageService;
        private readonly IUserService _userService = userService;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(MessageDto messageDto)
        {
            var userId = await _userService.GetUserIdAsync(User);

            messageDto.UserId = userId;

            var message = await _messageService.SendMessageAsync(messageDto);

            return RedirectToAction("Details", "Boards", new { id = message.BoardId });
        }
    }
}
