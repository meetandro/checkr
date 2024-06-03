using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(string id);

        User AddUser(User user);

        User UpdateUser(User user);

        User DeleteUser(string id);
    }
}
