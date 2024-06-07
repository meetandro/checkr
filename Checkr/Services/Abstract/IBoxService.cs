using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IBoxService
    {
        Box GetBoxById(int id);

        Box AddBox(BoxDto boxDto);

        Box UpdateBox(int boxId, BoxDto boxDto);

        Box DeleteBox(int id);
    }
}
