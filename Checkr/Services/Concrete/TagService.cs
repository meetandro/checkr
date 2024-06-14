using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class TagService(
        ITagRepository tagRepository,
        IBoardRepository boardRepository,
        IBoxRepository boxRepository) : ITagService
    {
        private readonly ITagRepository _tagRepository = tagRepository;
        private readonly IBoardRepository _boardRepository = boardRepository;
        private readonly IBoxRepository _boxRepository = boxRepository;

        public async Task<IEnumerable<Tag>> GetAllTagsForBoardAsync(int boardId)
        {
            return await _tagRepository.GetAllTagsForBoardAsync(boardId);
        }

        public async Task<Box> AddTagsToBoxAsync(int boxId, ICollection<int> tagsIds)
        {
            var box = await _boxRepository.GetByIdAsync(boxId) ?? throw new EntityNotFoundException();

            box.Tags.Clear();

            var tags = await _tagRepository.GetByIdsAsync(tagsIds);

            foreach (var tag in tags)
            {
                box.Tags.Add(tag);
            }

            return await _boxRepository.UpdateAsync(box);
        }

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
