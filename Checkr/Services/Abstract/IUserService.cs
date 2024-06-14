using Checkr.Entities;
using System.Security.Claims;

namespace Checkr.Services.Abstract
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(string id);

        Task<string> GetUserIdAsync(ClaimsPrincipal principal);

        Task<string?> GetUserIdByEmailAsync(string email);
    }
}
