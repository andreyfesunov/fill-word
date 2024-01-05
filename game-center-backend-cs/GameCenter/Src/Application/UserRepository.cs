using game_center_backend_cs.Domain.Models.User;
using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Infrastructure.Models.User;
using MongoDB.Bson;
using MongoDB.Driver;

namespace game_center_backend_cs.Application;

public class UserRepository : IUserRepository
{
    public UserModel Create(UserModel model)
    {
        var ormModel = User.ToDatabase(model);
        User.Create(ormModel);
        return model;
    }

    public UserModel FindById(string id)
    {
        var objectId = ObjectId.Parse(id);
        var model = User.Query()
            .Find(x => x.Id == objectId)
            .Single();
        return User.FromDatabase(model);
    }

    public UserModel FindByLogin(string login)
    {
        var model = User.Query()
            .Find(x => x.Login == login)
            .Single();
        return User.FromDatabase(model);
    }
}