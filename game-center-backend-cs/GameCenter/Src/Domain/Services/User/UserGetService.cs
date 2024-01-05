using game_center_backend_cs.Domain.Repositories;

namespace game_center_backend_cs.Domain.Services.User;

using BCrypt = BCrypt.Net.BCrypt;

public class UserGetService
{
    private readonly IUserRepository _userRepository;

    public UserGetService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string LogIn(string login, string password)
    {
        var model = _userRepository.FindByLogin(login);

        if (BCrypt.Verify(password, model.PasswordHash)) return model.Id;

        throw new Exception("Incorrect credentials");
    }
}