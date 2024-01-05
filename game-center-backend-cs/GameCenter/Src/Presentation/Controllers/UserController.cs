using game_center_backend_cs.Domain.DTOs.Requests;
using game_center_backend_cs.Domain.DTOs.Responses;
using game_center_backend_cs.Domain.Mappers;
using game_center_backend_cs.Domain.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace game_center_backend_cs.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserGetService _userGetService;

    public UserController(UserGetService userGetService)
    {
        _userGetService = userGetService;
    }

    [HttpPost]
    public ActionResult<LogInResponse> LogIn([FromBody] LogInRequest request)
    {
        var id = _userGetService.LogIn(request.Login, request.Password);
        return Ok(UserMapper.ToLogInResponse(id));
    }
}