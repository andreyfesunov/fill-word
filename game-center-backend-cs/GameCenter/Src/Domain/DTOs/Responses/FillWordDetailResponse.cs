using game_center_backend_cs.Domain.Models.FillWord;

namespace game_center_backend_cs.Domain.DTOs.Responses;

public class FillWordDetailResponse
{
    public required string Id { get; set; }
    public required FillWordElement[][] Matrix { get; set; }
    public required List<List<int>> FoundAnswers { get; set; }
}