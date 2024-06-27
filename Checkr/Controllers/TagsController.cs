using Checkr.Extensions;
using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    [Authorize]
    public class TagsController(ITagService tagService) : Controller
    {
        private readonly ITagService _tagService = tagService;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagDto tagDto)
        {
            if (!ModelState.IsValid)
            {
                return View(tagDto);
            }

            var tag = await _tagService.CreateTagAsync(tagDto);

            return RedirectToAction("Details", "Boards", new { id = tag.BoardId });
        }

        [HttpGet]
        [Authorize(Policy = "IsUserPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);

            var tagDto = tag.ToTagDto();

            return View(tagDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TagDto tagDto)
        {
            if (!ModelState.IsValid)
            {
                return View(tagDto);
            }

            var tag = await _tagService.UpdateTagAsync(id, tagDto);

            return RedirectToAction("Details", "Boards", new { id = tag.BoardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _tagService.DeleteTagAsync(id);

            return RedirectToAction("Details", "Boards", new { id = tag.BoardId });
        }
    }
}
