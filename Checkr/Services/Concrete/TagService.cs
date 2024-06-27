using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class TagService(
        ITagRepository tagRepository,
        IBoardRepository boardRepository) : ITagService
    {
        private readonly ITagRepository _tagRepository = tagRepository;
        private readonly IBoardRepository _boardRepository = boardRepository;

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _tagRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
        }

        public async Task<Tag> CreateTagAsync(TagDto tagDto)
        {
            var board = await _boardRepository.GetByIdAsync(tagDto.BoardId) ?? throw new EntityNotFoundException();

            var tag = new Tag
            {
                Name = tagDto.Name,
                Hex = tagDto.Hex,
                Board = board,
            };

            board.Tags.Add(tag);

            return await _tagRepository.CreateAsync(tag);
        }

        public async Task<Tag> UpdateTagAsync(int id, TagDto tagDto)
        {
            var tag = await _tagRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException();

            tag.Name = tagDto.Name;
            tag.Hex = tagDto.Hex;

            return await _tagRepository.UpdateAsync(tag);
        }

        public async Task<Tag> DeleteTagAsync(int tagId)
        {
            return await _tagRepository.DeleteAsync(tagId) ?? throw new EntityNotFoundException();
        }
    }
}
