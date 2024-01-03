using game_center_backend_cs.Domain.Models.FillWord;
using game_center_backend_cs.Infrastructure.Db;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_center_backend_cs.Infrastructure.Models.FillWord;

[CollectionName("FillWord")]
public class FillWord : DalModel<FillWord>, IOrmMapper<FillWord, FillWordModel>
{
    [BsonId] public ObjectId Id;
    [BsonElement("answers")] public List<List<int>> Answers;
    [BsonElement("foundAnswers")] public List<List<int>> FoundAnswers;
    [BsonElement("matrix")] public FillWordElement[][] Matrix;

    private FillWord(
        ObjectId id,
        FillWordElement[][] matrix,
        List<List<int>> answers,
        List<List<int>> foundAnswers
    )
    {
        Id = id;
        Matrix = matrix;
        Answers = answers;
        FoundAnswers = foundAnswers;
    }

    public static FillWord ToDatabase(FillWordModel model)
    {
        return new FillWord(
            ObjectId.Parse(model.Id),
            model.Matrix,
            model.Answers,
            model.FoundAnswers
        );
    }

    public static FillWordModel FromDatabase(FillWord model)
    {
        return new FillWordModel(
            model.Id.ToString(),
            model.Matrix,
            model.Answers,
            model.FoundAnswers
        );
    }
}