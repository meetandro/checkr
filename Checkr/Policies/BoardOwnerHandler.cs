using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Checkr.Policies
{
    public class BoardOwnerHandler(
        IBoardService boardService,
        IHttpContextAccessor httpContextAccessor) : AuthorizationHandler<BoardOwnerRequirement>
    {
        private readonly IBoardService _boardService = boardService;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            BoardOwnerRequirement requirement)
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return;
            }

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var boardId = int.Parse(_httpContextAccessor.HttpContext.Request.RouteValues["id"]!.ToString()!);
            var board = await _boardService.GetBoardByIdAsync(boardId);

            if (board is not null && board.OwnerId == userId)
            {
                context.Succeed(requirement);
            }
        }
    }

}
