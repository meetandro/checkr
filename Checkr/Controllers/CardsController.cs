using Checkr.Entities;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

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

        // TODO : UpdateCard, DeleteCard
    }
}
