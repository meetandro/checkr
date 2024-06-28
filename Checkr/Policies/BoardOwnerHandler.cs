using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Checkr.Policies
{
    public class BoardOwnerHandler(
        IHttpContextAccessor httpContextAccessor,
        IBoardService boardService) : AuthorizationHandler<BoardOwnerRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IBoardService _boardService = boardService;

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            BoardOwnerRequirement requirement)
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

            var boardIdString = _httpContextAccessor.HttpContext.Request.RouteValues["id"]?
                .ToString();
            if (boardIdString is null || !int.TryParse(boardIdString, out int boardId))
            {
                return;
            }

            var board = await _boardService.GetBoardByIdAsync(boardId);
            if (board is not null && board.OwnerId == userId)
            {
                context.Succeed(requirement);
            }
        }
    }
}
