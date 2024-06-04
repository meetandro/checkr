using Checkr.Entities;

namespace Checkr.Services.Abstract
{
    public interface IBoxService
    {
        Box AddBox(Box box, int boardId);

        Box UpdateBox(int boxId, Box box, int boardId);

        Box DeleteBox(int boxId, int boardId);
    }
}
