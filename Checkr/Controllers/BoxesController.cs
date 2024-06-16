using Checkr.Extensions;
using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    [Authorize]
    public class BoxesController(IBoxService boxService) : Controller
    {
        private readonly IBoxService _boxService = boxService;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BoxDto boxDto)
        {
            if (!ModelState.IsValid)
            {
                return View(boxDto);
            }

            var box = await _boxService.CreateBoxAsync(boxDto);

            return RedirectToAction("Details", "Boards", new { id = box.BoardId });
        }

        [HttpGet]
        [Authorize(Policy = "IsUserPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var box = await _boxService.GetBoxByIdAsync(id);

            var boxDto = box.ToBoxDto();

            return View(boxDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BoxDto boxDto)
        {
            if (!ModelState.IsValid)
            {
                return View(boxDto);
            }

            var box = await _boxService.UpdateBoxAsync(id, boxDto);

            return RedirectToAction("Details", "Boards", new { id = box.BoardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var box = await _boxService.DeleteBoxAsync(id);

            return RedirectToAction("Details", "Boards", new { id = box.BoardId });
        }
    }
}
