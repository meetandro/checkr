using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;
using Checkr.Models;

namespace Checkr.Services.Concrete
{
    public class BoardService(
        IBoardRepository boardRepository,
        ICardRepository cardRepository,
        IUserService userService,
        IFileService fileService) : IBoardService
    {
        private readonly IBoardRepository _boardRepository = boardRepository;
        private readonly ICardRepository _cardRepository = cardRepository;
        private readonly IUserService _userService = userService;
        private readonly IFileService _fileService = fileService;

        public async Task<IEnumerable<Board>> GetAllBoardsForUserAsync(string userId)
        {
            return await _boardRepository.GetAllBoardsForUserAsync(userId);
        }

        public async Task<Board> GetBoardByIdAsync(int boardId)
        {
            return await _boardRepository.GetByIdAsync(boardId)
                ?? throw new EntityNotFoundException();
        }

        public async Task<Board> CreateBoardAsync(BoardDto boardDto)
        {
            var user = await _userService.GetUserByIdAsync(boardDto.OwnerId);

            var board = new Board
            {
                Name = boardDto.Name,
                OwnerId = user.Id,
            };

            board.Users.Add(user);

            return await _boardRepository.CreateAsync(board);
        }

        public async Task<Board> UpdateBoardAsync(int boardId, BoardDto boardDto)
        {
            var board = await _boardRepository.GetByIdAsync(boardId)
                ?? throw new EntityNotFoundException();

            board.Name = boardDto.Name;

            return await _boardRepository.UpdateAsync(board);
        }

        public async Task<Board> DeleteBoardAsync(int boardId)
        {
            var cardImageFileNames = await _cardRepository.GetCardImageFileNamesByBoardIdAsync(boardId);

            foreach (var cardImageFileName in cardImageFileNames)
            {
                _fileService.DeleteFileInFolder(cardImageFileName, "images");
            }

            return await _boardRepository.DeleteAsync(boardId)
                ?? throw new EntityNotFoundException();
        }

        public async Task<Board> RemoveUserFromBoardAsync(int boardId, string userId)
        {
            var board = await _boardRepository.GetByIdAsync(boardId)
                ?? throw new EntityNotFoundException();

            var user = await _userService.GetUserByIdAsync(userId);

            board.Users.Remove(user);
            
            return await _boardRepository.UpdateAsync(board);
        }
    }
}
