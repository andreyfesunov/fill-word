using MongoDB.Bson;

namespace game_center_backend_cs.Domain.Models.User;

public class UserModel
{
    public UserModel(
        string? id,
        string login,
        string passwordHash
    )
    {
        Id = id ?? ObjectId.GenerateNewId().ToString();
        Login = login;
        PasswordHash = passwordHash;
    }

    public string Id { get; }
    public string Login { get; }
    public string PasswordHash { get; }
}