using game_center_backend_cs.Domain.Models.FillWord;
using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Infrastructure.Models.FillWord;
using MongoDB.Bson;
using MongoDB.Driver;

namespace game_center_backend_cs.Application;

public class FillWordRepository : IFillWordRepository
{
    public FillWordModel Create(FillWordModel model)
    {
        var dalModel = FillWord.ToDatabase(model);
        FillWord.Create(dalModel);
        return model;
    }

    public FillWordModel FindById(string id)
    {
        var objectId = ObjectId.Parse(id);
        var model = FillWord.Query()
            .Find(x => x.Id == objectId)
            .First();
        return FillWord.FromDatabase(model);
    }

    public void Update(FillWordModel model)
    {
        var objectId = ObjectId.Parse(model.Id);
        FillWord.Query().ReplaceOne(x => x.Id == objectId, FillWord.ToDatabase(model));
    }
}