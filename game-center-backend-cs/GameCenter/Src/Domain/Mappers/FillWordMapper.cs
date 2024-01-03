using game_center_backend_cs.Domain.DTOs.Responses;
using game_center_backend_cs.Domain.Enums;

namespace game_center_backend_cs.Domain.Mappers;

public static class FillWordMapper
{
    public static FillWordAttemptResponse ToAttemptResponse(FillWordAttemptStatusEnum status)
    {
        return new FillWordAttemptResponse
        {
            Status = status
        };
    }
}