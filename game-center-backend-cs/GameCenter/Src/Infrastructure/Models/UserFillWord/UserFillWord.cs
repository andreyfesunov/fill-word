using game_center_backend_cs.Domain.Models.UserFillWord;
using game_center_backend_cs.Infrastructure.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_center_backend_cs.Infrastructure.Models.UserFillWord;

[CollectionName("UserFillWord")]
public class UserFillWord : DalModel<UserFillWord>, IOrmMapper<UserFillWord, UserFillWordModel>
{
    [BsonId] public required ObjectId Id { get; init; }
    [BsonElement("userId")] public required ObjectId UserId { get; init; }
    [BsonElement("fillWordId")] public required ObjectId FillWordId { get; init; }
    [BsonElement("foundAnswers")] public required List<List<int>> FoundAnswers { get; init; }

    public static UserFillWord ToDatabase(UserFillWordModel model)
    {
        return new UserFillWord
        {
            Id = ObjectId.Parse(model.Id),
            UserId = ObjectId.Parse(model.UserId),
            FillWordId = ObjectId.Parse(model.FillWordId),
            FoundAnswers = model.FoundAnswers
        };
    }

    public static UserFillWordModel FromDatabase(UserFillWord model)
    {
        return new UserFillWordModel(
            model.Id.ToString(),
            model.UserId.ToString(),
            model.FillWordId.ToString(),
            model.FoundAnswers
        );
    }
}