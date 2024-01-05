using game_center_backend_cs.Domain.Models.User;

namespace game_center_backend_cs.Domain.Repositories;

public interface IUserRepository
{
    public UserModel Create(UserModel model);

    public UserModel FindById(string id);

    public UserModel FindByLogin(string login);
}