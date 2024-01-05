using game_center_backend_cs.Domain.Models.User;
using game_center_backend_cs.Infrastructure.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_center_backend_cs.Infrastructure.Models.User;

[CollectionName("Users")]
public class User : DalModel<User>, IOrmMapper<User, UserModel>
{
    [BsonId] public required ObjectId Id { get; init; }
    [BsonElement("login")] public required string Login { get; init; }
    [BsonElement("passwordHash")] public required string PasswordHash { get; init; }

    public static User ToDatabase(UserModel model)
    {
        return new User
        {
            Id = ObjectId.Parse(model.Id),
            Login = model.Login,
            PasswordHash = model.PasswordHash
        };
    }

    public static UserModel FromDatabase(User model)
    {
        return new UserModel(
            model.Id.ToString(),
            model.Login,
            model.PasswordHash
        );
    }
}