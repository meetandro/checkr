using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IBoxRepository
    {
        List<Box> GetAllBoxes();

        Box GetBoxById(int id);

        Box AddBox(Box box);

        Box UpdateBox(Box box);

        Box DeleteBox(int id);
    }
}
