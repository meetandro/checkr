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
        public async Task<IActionResult> Create(MessageDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return View(messageDto);
            }

            var userId = await _userService.GetUserIdAsync(User);

            messageDto.UserId = userId;

            var message = await _messageService.CreateMessageAsync(messageDto);

            return RedirectToAction("Details", "Boards", new { id = message.BoardId });
        }
    }
}
