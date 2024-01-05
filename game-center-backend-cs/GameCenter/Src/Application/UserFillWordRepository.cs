using game_center_backend_cs.Domain.Models.UserFillWord;
using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Infrastructure.Models.UserFillWord;
using MongoDB.Bson;
using MongoDB.Driver;

namespace game_center_backend_cs.Application;

public class UserFillWordRepository : IUserFillWordRepository
{
    public UserFillWordModel Create(UserFillWordModel model)
    {
        var dalModel = UserFillWord.ToDatabase(model);
        UserFillWord.Create(dalModel);
        return model;
    }

    public UserFillWordModel Find(string userId, string fillWordId)
    {
        var model = UserFillWord.Query()
            .Find(x => x.UserId.ToString() == userId && x.FillWordId.ToString() == fillWordId)
            .Single();
        return UserFillWord.FromDatabase(model);
    }

    public void Update(UserFillWordModel model)
    {
        var objectId = ObjectId.Parse(model.Id);
        UserFillWord.Query().ReplaceOne(x => x.Id == objectId, UserFillWord.ToDatabase(model));
    }
}