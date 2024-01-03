using MongoDB.Bson;

namespace game_center_backend_cs.Domain.Models.FillWord;

public class FillWordModel
{
    public FillWordModel(
        string? id,
        FillWordElement[][] matrix,
        List<List<int>> answers,
        List<List<int>>? foundAnswers = null
    )
    {
        Id = id ?? ObjectId.GenerateNewId().ToString();
        Matrix = matrix;
        Answers = answers;
        FoundAnswers = foundAnswers ?? new List<List<int>>();
    }

    public string Id { get; set; }
    public FillWordElement[][] Matrix { get; set; }
    public List<List<int>> Answers { get; set; }
    public List<List<int>> FoundAnswers { get; set; }
}