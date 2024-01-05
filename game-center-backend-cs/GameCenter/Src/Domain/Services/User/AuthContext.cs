using game_center_backend_cs.Domain.Models.User;

namespace game_center_backend_cs.Domain.Services.User;

public static class AuthContext
{
    private static UserModel? CurrentUser { get; set; }

    public static UserModel GetCurrentUser()
    {
        if (CurrentUser != null) return CurrentUser;
        throw new Exception("Current user is not set");
    }

    public static void SetCurrentUser(UserModel model)
    {
        CurrentUser = model;
    }
}