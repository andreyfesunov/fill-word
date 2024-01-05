using game_center_backend_cs.Domain.DTOs.Responses;

namespace game_center_backend_cs.Domain.Mappers;

public static class UserMapper
{
    public static LogInResponse ToLogInResponse(string id)
    {
        return new LogInResponse
        {
            Id = id
        };
    }
}