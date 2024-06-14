using Checkr.Extensions;
using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    [Authorize]
    public class ToDoItemsController(IToDoItemService toDoItemService) : Controller
    {
        private readonly IToDoItemService _toDoItemService = toDoItemService;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoItemDto toDoItemDto)
        {
            if (!ModelState.IsValid)
            {
                return View(toDoItemDto);
            }

            var toDoItem = await _toDoItemService.CreateToDoItemAsync(toDoItemDto);

            return RedirectToAction("Details", "Boards", new { id = toDoItem.Card.Box.BoardId });
        }

        [HttpGet]
        [Authorize(Policy = "IsUserPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var toDoItem = await _toDoItemService.GetToDoItemByIdAsync(id);

            var toDoItemDto = toDoItem.ToToDoItemDto();

            return View(toDoItemDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ToDoItemDto toDoItemDto)
        {
            if (!ModelState.IsValid)
            {
                return View(toDoItemDto);
            }

            var toDoItem = await _toDoItemService.UpdateToDoItemAsync(id, toDoItemDto);

            return RedirectToAction("Details", "Boards", new { id = toDoItem.Card.Box.BoardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var toDoItem = await _toDoItemService.DeleteToDoItemAsync(id);

            return RedirectToAction("Details", "Boards", new { id = toDoItem.Card.Box.BoardId });
        }
    }
}
