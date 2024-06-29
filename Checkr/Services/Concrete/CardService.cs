using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class CardService(
        ICardRepository cardRepository,
        IBoxRepository boxRepository,
        IFileService fileService) : ICardService
    {
        private readonly ICardRepository _cardRepository = cardRepository;
        private readonly IBoxRepository _boxRepository = boxRepository;
        private readonly IFileService _fileService = fileService;

        public async Task<Card> GetCardByIdAsync(int cardId)
        {
            return await _cardRepository.GetByIdAsync(cardId)
                ?? throw new EntityNotFoundException();
        }

        public async Task<Card> CreateCardAsync(CardDto cardDto)
        {
            var card = new Card
            {
                Content = cardDto.Content,
                Name = cardDto.Name,
                CreatedAt = DateTime.UtcNow,
                DueDate = cardDto.DueDate,
                Box = await _boxRepository.GetByIdAsync(cardDto.BoxId)
                ?? throw new EntityNotFoundException()
            };

            var imageFile = cardDto.ImageFile;
            if (imageFile is not null)
            {
                var cardImageFileName = await _fileService.SaveFileInFolderAsync(imageFile, "images");

                card.ImageFileName = cardImageFileName;
            }

            return await _cardRepository.CreateAsync(card);
        }

        public async Task<Card> UpdateCardAsync(int cardId, CardDto cardDto)
        {
            var card = await _cardRepository.GetByIdAsync(cardId)
                ?? throw new EntityNotFoundException();

            card.Name = cardDto.Name;
            card.Content = cardDto.Content;
            card.DueDate = cardDto.DueDate;

            var imageFile = cardDto.ImageFile;
            if (imageFile is not null)
            {
                var imageFileName = await _fileService.SaveFileInFolderAsync(imageFile, "images");

                if (!string.IsNullOrEmpty(card.ImageFileName))
                {
                    _fileService.DeleteFileInFolder(cardDto.ImageFileName, "images");
                }

                card.ImageFileName = imageFileName;
            }

            return await _cardRepository.UpdateAsync(card);
        }

        public async Task<Card> DeleteCardAsync(int cardId)
        {
            var card = await _cardRepository.GetByIdAsync(cardId)
                ?? throw new EntityNotFoundException();

            if (!string.IsNullOrEmpty(card.ImageFileName))
            {
                _fileService.DeleteFileInFolder(card.ImageFileName, "images");
            }

            return await _cardRepository.DeleteAsync(cardId)
                ?? throw new EntityNotFoundException();
        }
    }
}
