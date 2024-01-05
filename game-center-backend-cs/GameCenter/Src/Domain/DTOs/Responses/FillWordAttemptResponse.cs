using game_center_backend_cs.Domain.Enums;

namespace game_center_backend_cs.Domain.DTOs.Responses;

public class FillWordAttemptResponse
{
    public required FillWordAttemptStatusEnum Status { get; init; }
}