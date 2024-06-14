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

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BoardUserRequirement requirement)
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return;
            }

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var controller = _httpContextAccessor.HttpContext.Request.RouteValues["controller"]!.ToString();

            var routeIdAsString = _httpContextAccessor.HttpContext.Request.RouteValues["id"]?.ToString();

            try
            {
                if (routeIdAsString is null)
                {
                    switch (controller)
                    {
                        case "Boxes" when _httpContextAccessor.HttpContext.Request.Query.ContainsKey("BoardId") &&
                        int.TryParse(_httpContextAccessor.HttpContext.Request.Query["BoardId"], out int boardId):
                            {
                                var board = await _boardService.GetBoardByIdAsync(boardId);
                                if (board is not null && board.Users.Any(u => u.Id == userId))
                                {
                                    context.Succeed(requirement);
                                }
                                break;
                            }

                        case "Tags" when _httpContextAccessor.HttpContext.Request.Query.ContainsKey("BoxId") &&
                        int.TryParse(_httpContextAccessor.HttpContext.Request.Query["BoxId"], out int boxId):
                            {
                                var box = await _boxService.GetBoxByIdAsync(boxId);
                                if (box is not null)
                                {
                                    var board = await _boardService.GetBoardByIdAsync(box.BoardId);
                                    if (board is not null && board.Users.Any(u => u.Id == userId))
                                    {
                                        context.Succeed(requirement);
                                    }
                                }
                                break;
                            }

                        default:
                            break;
                    }
                }
                else if (routeIdAsString is not null)
                {
                    var id = int.Parse(routeIdAsString);

                    switch (controller)
                    {
                        case "Boards":
                            var board = await _boardService.GetBoardByIdAsync(id);
                            if (board is not null && board.Users.Any(u => u.Id == userId))
                            {
                                context.Succeed(requirement);
                            }
                            break;

                        case "Boxes":
                            var box = await _boxService.GetBoxByIdAsync(id);
                            var boardFromBox = await _boardService.GetBoardByIdAsync(box.BoardId);
                            if (boardFromBox is not null && boardFromBox.Users.Any(u => u.Id == userId))
                            {
                                context.Succeed(requirement);
                            }
                            break;

                        case "Tags":
                            var tag = await _tagService.GetTagByIdAsync(id);
                            var boardFromTag = await _boardService.GetBoardByIdAsync(tag.BoardId);
                            if (boardFromTag is not null && boardFromTag.Users.Any(u => u.Id == userId))
                            {
                                context.Succeed(requirement);
                            }
                            break;

                        case "Cards":
                            var card = await _cardService.GetCardByIdAsync(id);
                            var boardFromCard = await _boardService.GetBoardByIdAsync(card.Box.BoardId);
                            if (boardFromCard is not null && boardFromCard.Users.Any(u => u.Id == userId))
                            {
                                context.Succeed(requirement);
                            }
                            break;

                        case "ToDoItems":
                            var toDoItem = await _toDoItemService.GetToDoItemByIdAsync(id);
                            var boardFromToDoItem = await _boardService.GetBoardByIdAsync(toDoItem.Card.Box.BoardId);
                            if (boardFromToDoItem is not null && boardFromToDoItem.Users.Any(u => u.Id == userId))
                            {
                                context.Succeed(requirement);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                context.Fail();
            }
        }
    }
}
