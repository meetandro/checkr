using Checkr.Entities;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Checkr.Policies
{
    public class BoardUserHandler(
        IHttpContextAccessor httpContextAccessor,
        IBoardService boardService,
        IBoxService boxService,
        ICardService cardService,
        ITagService tagService,
        IToDoItemService toDoItemService) : AuthorizationHandler<BoardUserRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IBoardService _boardService = boardService;
        private readonly IBoxService _boxService = boxService;
        private readonly ICardService _cardService = cardService;
        private readonly ITagService _tagService = tagService;
        private readonly IToDoItemService _toDoItemService = toDoItemService;

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            BoardUserRequirement requirement)
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return;
            }

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var controller = _httpContextAccessor.HttpContext.Request.RouteValues["controller"]!
                .ToString();
            var idString = _httpContextAccessor.HttpContext.Request.RouteValues["id"]?
                .ToString();

            bool isBoardUser = false;

            try
            {
                if (idString is not null)
                {
                    var id = int.Parse(idString);

                    isBoardUser = controller switch
                    {
                        "Boards" => await IsUserInBoardAsync(id),

                        "Boxes" => await _boxService.GetBoxByIdAsync(id) is Box box
                            && await IsUserInBoardAsync(box.BoardId),

                        "Tags" => await _tagService.GetTagByIdAsync(id) is Tag tag
                            && await IsUserInBoardAsync(tag.BoardId),

                        "Cards" => await _cardService.GetCardByIdAsync(id) is Card card
                            && await IsUserInBoardAsync(card.Box.BoardId),

                        "ToDoItems" => await _toDoItemService.GetToDoItemByIdAsync(id) is ToDoItem toDoItem
                            && await IsUserInBoardAsync(toDoItem.Card.Box.BoardId),

                        _ => false
                    };
                }

                if (isBoardUser)
                {
                    context.Succeed(requirement);
                }

                async Task<bool> IsUserInBoardAsync(int boardId)
                {
                    var board = await _boardService.GetBoardByIdAsync(boardId);

                    return board is not null && board.Users.Any(u => u.Id == userId);
                }
            }
            catch (Exception)
            {
                context.Fail();
            }
        }
    }
}
