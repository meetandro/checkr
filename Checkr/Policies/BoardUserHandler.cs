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
        ITagService tagService,
        ICardService cardService,
        IToDoItemService toDoItemService) : AuthorizationHandler<BoardUserRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IBoardService _boardService = boardService;
        private readonly IBoxService _boxService = boxService;
        private readonly ITagService _tagService = tagService;
        private readonly ICardService _cardService = cardService;
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
            if (userId is null)
            {
                return;
            }

            var controller = _httpContextAccessor.HttpContext.Request.RouteValues["controller"]?
                .ToString();
            if (controller is null)
            {
                return;
            }

            var idString = _httpContextAccessor.HttpContext.Request.RouteValues["id"]?
                .ToString();
            if (idString is null || !int.TryParse(idString, out int id))
            {
                return;
            }

            try
            {
                if (await HasPermissionAsync(controller, id))
                {
                    context.Succeed(requirement);
                }
            }
            catch (Exception)
            {
                context.Fail();
            }

            async Task<bool> HasPermissionAsync(string controller, int id) => controller switch
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

            async Task<bool> IsUserInBoardAsync(int boardId)
            {
                var board = await _boardService.GetBoardByIdAsync(boardId);

                return board is not null && board.Users.Any(u => u.Id == userId);
            }
        }
    }
}
