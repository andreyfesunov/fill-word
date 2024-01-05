using game_center_backend_cs.Domain.Models.UserFillWord;

namespace game_center_backend_cs.Domain.Repositories;

public interface IUserFillWordRepository
{
    public UserFillWordModel Create(UserFillWordModel model);

    public UserFillWordModel Find(string userId, string fillWordId);

    public void Update(UserFillWordModel model);
}