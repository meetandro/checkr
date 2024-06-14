using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Extensions
{
    public static class CardExtension
    {
        public static CardDto ToCardDto(this Card card)
        {
            return new CardDto
            {
                BoxId = card.BoxId,
                Content = card.Content,
                Name = card.Name,
                ImageFileName = card.ImageFileName,
                CreatedAt = card.CreatedAt,
                DueDate = card.DueDate
            };
        }
    }
}
