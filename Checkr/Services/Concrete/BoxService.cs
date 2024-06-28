using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class BoxService(
        IBoxRepository boxRepository,
        IBoardRepository boardRepository,
        ICardRepository cardRepository,
        ITagRepository tagRepository,
        IFileService fileService) : IBoxService
    {
        private readonly IBoxRepository _boxRepository = boxRepository;
        private readonly IBoardRepository _boardRepository = boardRepository;
        private readonly ICardRepository _cardRepository = cardRepository;
        private readonly ITagRepository _tagRepository = tagRepository;
        private readonly IFileService _fileService = fileService;

        public async Task<Box> GetBoxByIdAsync(int id)
        {
            return await _boxRepository.GetByIdAsync(id)
                ?? throw new EntityNotFoundException();
        }

        public async Task<Box> CreateBoxAsync(BoxDto boxDto)
        {
            var box = new Box()
            {
                Name = boxDto.Name,
                Board = await _boardRepository.GetByIdAsync(boxDto.BoardId)
                ?? throw new EntityNotFoundException()
            };

            return await _boxRepository.CreateAsync(box);
        }

        public async Task<Box> UpdateBoxAsync(int boxId, BoxDto boxDto)
        {
            var box = await _boxRepository.GetByIdAsync(boxId)
                ?? throw new EntityNotFoundException();

            box.Name = boxDto.Name;

            box.Tags.Clear();

            var tags = await _tagRepository.GetByIdsAsync(boxDto.SelectedTagsIds);

            foreach (var tag in tags)
            {
                box.Tags.Add(tag);
            }

            return await _boxRepository.UpdateAsync(box);
        }

        public async Task<Box> DeleteBoxAsync(int id)
        {
            var cardImageFileNames = await _cardRepository.GetCardImageFileNamesByBoxIdAsync(id);

            foreach (var cardImageFileName in cardImageFileNames)
            {
                _fileService.DeleteFileInFolder(cardImageFileName, "images");
            }

            return await _boxRepository.DeleteAsync(id)
                ?? throw new EntityNotFoundException();
        }
    }
}
