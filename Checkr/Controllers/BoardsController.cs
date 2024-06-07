using Checkr.Entities;
using Checkr.Extensions;
using Checkr.Services.Abstract;
using Checkr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Checkr.Controllers
{
    public class BoardsController(IBoardService boardService, UserManager<User> userManager) : Controller
    {
        private readonly IBoardService _boardService = boardService;
        private readonly UserManager<User> _userManager = userManager;

        public IActionResult GetAllBoardsForUser()
        {
            var userId = _userManager.GetUserId(User);
            var boards = _boardService.GetAllBoardsForUser(userId);
            return View(boards);
        }

        public IActionResult GetBoardDetails(int id)
        {
            var board = _boardService.GetBoardById(id);

            return View(board);
        }

        public IActionResult GetAllUsersForBoard(int id)
        {
            var board = _boardService.GetBoardById(id);
            return View(board);
        }

        public IActionResult AddBoard()
        {
            ViewData["OwnerId"] = _userManager.GetUserId(User);

            return View();
        }

        [HttpPost]
        public IActionResult AddBoard(BoardDto boardDto)
        {
            if (!ModelState.IsValid)
            {
                return View(boardDto);
            }

            _boardService.AddBoard(boardDto);

            return RedirectToAction(nameof(GetAllBoardsForUser));
        }

        public IActionResult AddUserToBoard(int boardId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUserToBoard(int id, string userName)
        {
            _boardService.AddUserToBoard(id, userName);

            return RedirectToAction(nameof(GetAllBoardsForUser));
        }

        [HttpPost]
        public IActionResult RemoveUserFromBoard(int id, string userId)
        {
            var board = _boardService.GetBoardById(id);
            if (board.OwnerId == _userManager.GetUserId(User))
            {
                _boardService.RemoveUserFromBoard(id, userId);

                return RedirectToAction(nameof(GetAllUsersForBoard), new { id });
            }
            return Forbid();
        }

        [HttpPost]
        public IActionResult LeaveBoard(int id)
        {
            var board = _boardService.GetBoardById(id);
            if (board.OwnerId == _userManager.GetUserId(User))
            {
                return Forbid();
            }

            var userId = _userManager.GetUserId(User);
            _boardService.RemoveUserFromBoard(id, userId);

            return RedirectToAction(nameof(GetAllBoardsForUser));
        }

        public IActionResult UpdateBoard(int id)
        {
            var board = _boardService.GetBoardById(id);

            var boardDto = board.ToBoardDto();

            return View(boardDto);
        }

        [HttpPost]
        public IActionResult UpdateBoard(int id, BoardDto boardDto)
        {
            if (!ModelState.IsValid)
            {
                return View(boardDto);
            }

            _boardService.UpdateBoard(id, boardDto);

            return RedirectToAction(nameof(GetAllBoardsForUser));
        }

        [HttpPost]
        public IActionResult DeleteBoard(int id)
        {
            var board = _boardService.GetBoardById(id);
            if (board.OwnerId == _userManager.GetUserId(User))
            {
                _boardService.DeleteBoard(id);

                return RedirectToAction(nameof(GetAllBoardsForUser));
            }
            return Forbid();
        }
    }
}
