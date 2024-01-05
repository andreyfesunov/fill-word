using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Domain.Services.User;

namespace game_center_backend_cs.Presentation.Middleware;

public class SimpleAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IUserRepository _userRepository;

    public SimpleAuthenticationMiddleware(RequestDelegate next, IUserRepository userRepository)
    {
        _next = next;
        _userRepository = userRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        var userId =
            context.Request.Headers["UserId"];

        if (!string.IsNullOrWhiteSpace(userId))
        {
            AuthContext.SetCurrentUser(_userRepository.FindById(userId.ToString()));
            context.Items["UserId"] = userId;
        }

        await _next(context);
    }
}