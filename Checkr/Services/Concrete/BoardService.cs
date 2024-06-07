using Checkr.Entities;
using Checkr.Extensions;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;
using Checkr.Models;
using Microsoft.AspNetCore.Identity;

namespace Checkr.Services.Concrete
{
    public class BoardService(IBoardRepository boardRepository, UserManager<User> userManager) : IBoardService
    {
        private readonly IBoardRepository _boardRepository = boardRepository;
        private readonly UserManager<User> _userManager = userManager;

        public List<Board> GetAllBoardsForUser(string userId)
        {
            return _boardRepository.GetAllBoardsForUser(userId);
        }

        public Board GetBoardById(int id)
        {
            return _boardRepository.GetBoardById(id);
        }

        public Board AddBoard(BoardDto boardDto)
        {
            var board = boardDto.ToBoard();
            var user = _userManager.FindByIdAsync(boardDto.OwnerId).Result;
            board.Users.Add(user);
            return _boardRepository.AddBoard(board);
        }

        public Board AddUserToBoard(int boardId, string userName)
        {
            var board = _boardRepository.GetBoardById(boardId);
            var user = _userManager.FindByNameAsync(userName).Result;
            board.Users.Add(user);
            _boardRepository.UpdateBoard(board);
            return board;
        }

        public Board RemoveUserFromBoard(int boardId, string userId)
        {
            var board = _boardRepository.GetBoardById(boardId);
            var user = _userManager.FindByIdAsync(userId).Result;
            board.Users.Remove(user);
            _boardRepository.UpdateBoard(board);
            return board;
        }

        public Board UpdateBoard(int boardId, BoardDto boardDto)
        {
            var boardToUpdate = _boardRepository.GetBoardById(boardId);

            boardToUpdate.BoardName = boardDto.BoardName;

            return _boardRepository.UpdateBoard(boardToUpdate);
        }

        public Board DeleteBoard(int id)
        {
            return _boardRepository.DeleteBoard(id);
        }
    }
}
