using game_center_backend_cs.Domain.DTOs.Responses;
using game_center_backend_cs.Domain.Enums;
using game_center_backend_cs.Domain.Models.FillWord;
using game_center_backend_cs.Domain.Models.UserFillWord;

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

    public static FillWordDetailResponse ToDetailResponse(FillWordModel model, UserFillWordModel relationModel)
    {
        return new FillWordDetailResponse
        {
            Id = model.Id,
            Matrix = model.Matrix,
            FoundAnswers = relationModel.FoundAnswers
        };
    }
}