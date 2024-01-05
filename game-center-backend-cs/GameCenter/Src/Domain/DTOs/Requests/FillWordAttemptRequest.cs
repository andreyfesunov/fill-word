namespace game_center_backend_cs.Domain.DTOs.Requests;

public class FillWordAttemptRequest
{
    public required List<int> AnswerIds { get; set; }
    public required string Id { get; set; }
}