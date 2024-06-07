using Checkr.Entities;
using Checkr.Extensions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class BoxService(IBoxRepository boxRepository) : IBoxService
    {
        private readonly IBoxRepository _boxRepository = boxRepository;

        public Box GetBoxById(int id)
        {
            return _boxRepository.GetBoxById(id);
        }

        public Box AddBox(BoxDto boxDto)
        {
            var box = boxDto.ToBox();

            return _boxRepository.AddBox(box);
        }

        public Box UpdateBox(int boxId, BoxDto boxDto)
        {
            var boxToUpdate = _boxRepository.GetBoxById(boxId);

            boxToUpdate.BoxName = boxDto.BoxName;

            return _boxRepository.UpdateBox(boxToUpdate);
        }

        public Box DeleteBox(int id)
        {
            return _boxRepository.DeleteBox(id);
        }
    }
}
