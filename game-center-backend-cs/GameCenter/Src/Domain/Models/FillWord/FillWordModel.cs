using MongoDB.Bson;

namespace game_center_backend_cs.Domain.Models.FillWord;

public class FillWordModel
{
    public FillWordModel(
        string? id,
        FillWordElement[][] matrix,
        List<List<int>> answers
    )
    {
        Id = id ?? ObjectId.GenerateNewId().ToString();
        Matrix = matrix;
        Answers = answers;
    }

    public string Id { get; }
    public FillWordElement[][] Matrix { get; }
    public List<List<int>> Answers { get; }
}