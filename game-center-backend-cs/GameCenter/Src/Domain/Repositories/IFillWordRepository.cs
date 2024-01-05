using game_center_backend_cs.Domain.Models.FillWord;

namespace game_center_backend_cs.Domain.Repositories;

public interface IFillWordRepository
{
    public FillWordModel Create(FillWordModel model);

    public FillWordModel FindById(string id);

    public List<FillWordModel> List();

    public void Update(FillWordModel model);
}