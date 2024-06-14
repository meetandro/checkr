using Checkr.Entities;
using Checkr.Services.Abstract;
using Checkr.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Checkr.Extensions;
using Checkr.Models;
using Checkr.Services.Concrete;

namespace Checkr.Controllers
{
    public class CardsController(ICardService cardService) : Controller
    {
        private readonly ICardService _cardService = cardService;

        public IActionResult AddCard(int boxId)
        {
            ViewData["BoxId"] = boxId;

            return View();
        }

        [HttpPost]
        public IActionResult AddCard(Card card)
        {
            if (!ModelState.IsValid)
            {
                return View(card);
            }

            _cardService.AddCard(card);

            return RedirectToAction("GetAllBoardsForUser", "Boards");
        }

        [HttpGet]
        public IActionResult UpdateCard(int id)
        {
            var card = _cardService.GetCardById(id);

            var cardDto = card.ToCardDto();

            return View(cardDto);
        }

        [HttpPost]
        public IActionResult UpdateCard(int cardId, Card card)
        {
            if (!ModelState.IsValid)
            {
                return View(card);
            }
            _cardService.UpdateCard(cardId, card);

            return RedirectToAction("GetAllBoardsForUser", "Boards");
        }

        [HttpPost]
        public IActionResult DeleteCard(int id)
        {
            var card = _cardService.GetCardById(id);

            _cardService.DeleteCard(id);

            return RedirectToAction("GetAllBoardsForUser", "Boards");
        }
    }
}
