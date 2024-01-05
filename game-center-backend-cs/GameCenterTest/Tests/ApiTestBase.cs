using game_center_backend_cs.Domain.Models.User;
using game_center_backend_cs.Infrastructure.Models.User;
using MongoDB.Driver;

namespace GameCenterTest.Tests;

public abstract class ApiTestBase
{
    protected readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("http://localhost:5041")
    };

    protected readonly UserModel UserModel = new(
        "6595ac07a73ece146c93f56a",
        "user1",
        BCrypt.Net.BCrypt.HashPassword("password")
    );

    private bool _isFirstTest = true;

    [SetUp]
    public void SetUp()
    {
        try
        {
            User.Query()
                .Find(x => x.Login == UserModel.Login)
                .First();
        }
        catch (InvalidOperationException)
        {
            User.Create(User.ToDatabase(UserModel));
        }

        if (!_isFirstTest) return;
        HttpClient.DefaultRequestHeaders.Add("UserId", UserModel.Id);
        _isFirstTest = false;
    }
}