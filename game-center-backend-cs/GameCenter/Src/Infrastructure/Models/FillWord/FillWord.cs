using game_center_backend_cs.Domain.Models.FillWord;
using game_center_backend_cs.Infrastructure.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_center_backend_cs.Infrastructure.Models.FillWord;

[CollectionName("FillWord")]
public class FillWord : DalModel<FillWord>, IOrmMapper<FillWord, FillWordModel>
{
    [BsonId] public required ObjectId Id { get; init; }
    [BsonElement("answers")] public required List<List<int>> Answers { get; init; }
    [BsonElement("matrix")] public required FillWordElement[][] Matrix { get; init; }

    public static FillWord ToDatabase(FillWordModel model)
    {
        return new FillWord
        {
            Id = ObjectId.Parse(model.Id),
            Matrix = model.Matrix,
            Answers = model.Answers
        };
    }

    public static FillWordModel FromDatabase(FillWord model)
    {
        return new FillWordModel(
            model.Id.ToString(),
            model.Matrix,
            model.Answers
        );
    }
}