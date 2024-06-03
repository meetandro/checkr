using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface ILabelRepository
    {
        List<Label> GetAllLabels();

        Label GetLabelById(int id);

        Label AddLabel(Label label);

        Label UpdateLabel(Label label);

        Label DeleteLabel(int id);
    }
}
