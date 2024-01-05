using MongoDB.Bson;

namespace game_center_backend_cs.Domain.Models.UserFillWord;

public class UserFillWordModel
{
    public UserFillWordModel(string? id, string userId, string fillWordId, List<List<int>>? foundAnswers = null)
    {
        Id = id ?? ObjectId.GenerateNewId().ToString();
        UserId = userId;
        FillWordId = fillWordId;
        FoundAnswers = foundAnswers ?? new List<List<int>>();
    }

    public string Id { get; }
    public string UserId { get; }
    public string FillWordId { get; }
    public List<List<int>> FoundAnswers { get; }
}