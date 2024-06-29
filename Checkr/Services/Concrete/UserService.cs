using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Checkr.Services.Concrete
{
    public class UserService(UserManager<User> userManager) : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;

        public async Task<User> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new EntityNotFoundException();

            return user;
        }

        public async Task<string> GetUserIdAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal)
                ?? throw new EntityNotFoundException();

            var userId = user.Id;

            return userId;
        }

        public async Task<string?> GetUserIdByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var userId = user?.Id;

            return userId;
        }
    }
}
