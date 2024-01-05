using System.Text;
using game_center_backend_cs.Domain.DTOs.Requests;
using Newtonsoft.Json;

namespace GameCenterTest.Tests.Api.User;

[TestFixture]
public class UserGetApiTest : ApiTestBase
{
    private async Task<HttpResponseMessage> LogIn(string login, string password)
    {
        var httpContent = new LogInRequest
        {
            Login = login,
            Password = password
        };
        var json = JsonConvert.SerializeObject(httpContent);

        // Создание HTTP-запроса
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/User");
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        // Выполнение POST-запроса
        return await HttpClient.SendAsync(request);
    }

    [Test]
    public async Task LogInTest()
    {
        var response = await LogIn("user1", "password");
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }
}