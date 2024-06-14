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
                CardName = card.CardName,
                CardContent = card.CardContent,
                CardImageFileName = card.CardImageFileName,
                DueDate = card.DueDate,
                BoxId = card.BoxId
            };
        }
    }
}
