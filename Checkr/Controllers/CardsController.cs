using Checkr.Extensions;
using Checkr.Models;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    [Authorize]
    public class CardsController(ICardService cardService) : Controller
    {
        private readonly ICardService _cardService = cardService;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CardDto cardDto)
        {
            if (!ModelState.IsValid)
            {
                return View(cardDto);
            }

            var card = await _cardService.CreateCardAsync(cardDto);

            return RedirectToAction("Details", "Boards", new { id = card.Box.BoardId });
        }

        [HttpGet]
        [Authorize(Policy = "IsUserPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var card = await _cardService.GetCardByIdAsync(id);

            var cardDto = card.ToCardDto();

            return View(cardDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CardDto cardDto)
        {
            if (!ModelState.IsValid)
            {
                return View(cardDto);
            }

            var card = await _cardService.UpdateCardAsync(id, cardDto);

            return RedirectToAction("Details", "Boards", new { id = card.Box.BoardId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _cardService.DeleteCardAsync(id);

            return RedirectToAction("Details", "Boards", new { id = card.Box.BoardId });
        }
    }
}
