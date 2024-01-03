namespace game_center_backend_cs.Domain.DTOs.Requests;

public class FillWordAttemptRequest
{
    public string Id { get; set; }

    public List<int> AnswerIds { get; set; }
}