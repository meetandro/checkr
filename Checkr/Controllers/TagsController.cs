using Microsoft.AspNetCore.Mvc;
using Checkr.Models;
using Checkr.Entities;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost]
    public ActionResult<Tag> AddTag([FromBody] TagDto tagDto)
    {
        var tag = _tagService.AddTag(tagDto);
        return CreatedAtAction(nameof(GetAllTagsForBox), new { id = tag.Id }, tag);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTag(int id, [FromBody] TagDto tagDto)
    {
        if (id != tagDto.Id)
        {
            return BadRequest();
        }

        var tag = _tagService.UpdateTag(tagDto);
        if (tag == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTag(int id)
    {
        _tagService.DeleteTag(id);
        return NoContent();
    }

    [HttpPost("{tagId}/boxes/{boxId}")]
    public IActionResult AddTagToBox(int tagId, int boxId)
    {
        _tagService.AddTagToBox(tagId, boxId);
        return NoContent();
    }

    [HttpDelete("{tagId}/boxes/{boxId}")]
    public IActionResult RemoveTagFromBox(int tagId, int boxId)
    {
        _tagService.RemoveTagFromBox(tagId, boxId);
        return NoContent();
    }

    [HttpGet("boxes/{boxId}")]
    public ActionResult<List<Tag>> GetAllTagsForBox(int boxId)
    {
        var tags = _tagService.GetAllTagsForBox(boxId);
        return Ok(tags);
    }
}