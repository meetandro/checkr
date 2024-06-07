using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            var user = _context.Users
                .Include("Messages")
                .Include("Boards")
                .FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
