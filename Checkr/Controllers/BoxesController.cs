using Checkr.Extensions;
using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    public class BoxesController(IBoxService boxService) : Controller
    {
        private readonly IBoxService _boxService = boxService;

        // asp-route-id || input value
        public IActionResult AddBoxToBoard(int boardId)
        {
            ViewData["BoardId"] = boardId;

            return View();
        }

        [HttpPost]
        public IActionResult AddBoxToBoard(BoxDto boxDto)
        {
            if (!ModelState.IsValid)
            {
                return View(boxDto);
            }

            _boxService.AddBox(boxDto);

            return RedirectToAction("GetBoardDetails", "Boards", new { id = boxDto.BoardId });
        }

        [HttpGet]
        public IActionResult UpdateBox(int id)
        {
            var box = _boxService.GetBoxById(id);

            var boxDto = box.ToBoxDto();

            return View(boxDto);
        }

        [HttpPost]
        public IActionResult UpdateBox(int id, BoxDto boxDto)
        {
            if (!ModelState.IsValid)
            {
                return View(boxDto);
            }

            _boxService.UpdateBox(id, boxDto);

            return RedirectToAction("GetBoardDetails", "Boards", new { id = boxDto.BoardId });
        }

        [HttpPost]
        public IActionResult DeleteBox(int id)
        {
            var box = _boxService.GetBoxById(id);

            _boxService.DeleteBox(id);

            return RedirectToAction("GetBoardDetails", "Boards", new { id = box.BoardId });
        }
    }
}
