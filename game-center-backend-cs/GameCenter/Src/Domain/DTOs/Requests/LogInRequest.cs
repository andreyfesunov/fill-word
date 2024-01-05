namespace game_center_backend_cs.Domain.DTOs.Requests;

public class LogInRequest
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}