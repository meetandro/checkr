using Checkr.Extensions;
using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    [Authorize]
    public class TagsController(ITagService tagService, IBoxService boxService) : Controller
    {
        private readonly ITagService _tagService = tagService;
        private readonly IBoxService _boxService = boxService;

        [HttpGet]
        [Authorize(Policy = "IsUserPolicy")]
        public async Task<IActionResult> Create(int boxId)
        {
            var box = await _boxService.GetBoxByIdAsync(boxId);

            return View(new TagDto { BoardId = box.BoardId });
        }

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

        [HttpGet]
        [Authorize(Policy = "IsUserPolicy")]
        public async Task<IActionResult> AddTagToBox(int boxId)
        {
            var box = await _boxService.GetBoxByIdAsync(boxId);

            var tagsViewModel = new TagsViewModel
            {
                BoxId = box.Id,
                BoxTags = box.Tags,
                BoardTags = await _tagService.GetAllTagsForBoardAsync(box.BoardId)
            };

            return View(tagsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTagToBox(TagsViewModel tagsViewModel)
        {
            var box = await _tagService.AddTagsToBoxAsync(tagsViewModel.BoxId, tagsViewModel.SelectedTagsIds);

            return RedirectToAction("Details", "Boards", new { id = box.BoardId });
        }
    }
}
