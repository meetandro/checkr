using Checkr.Entities;
using System.Security.Claims;

namespace Checkr.Services.Abstract
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(string userId);

        Task<string> GetUserIdAsync(ClaimsPrincipal principal);

        Task<string?> GetUserIdByEmailAsync(string email);
    }
}
