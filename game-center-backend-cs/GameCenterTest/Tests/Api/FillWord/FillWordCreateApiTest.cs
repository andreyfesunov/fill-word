using System.Text;
using game_center_backend_cs.Domain.DTOs.Requests;
using Newtonsoft.Json;

namespace GameCenterTest.Tests.Api.FillWord;

[TestFixture]
public class FillWordCreateApiTest : ApiTestBase
{
    private async Task<HttpResponseMessage> Create(int size)
    {
        var httpContent = new FillWordCreateRequest
        {
            Size = size
        };
        var json = JsonConvert.SerializeObject(httpContent);

        // Создание HTTP-запроса
        var request = new HttpRequestMessage(HttpMethod.Put, "/api/FillWord");
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        // Выполнение PUT-запроса
        return await HttpClient.SendAsync(request);
    }

    // SUCCESS

    [Test]
    public async Task TestCreateSizeThree()
    {
        var response = await Create(3);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task TestCreateSizeFour()
    {
        var response = await Create(4);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task TestCreateSizeFive()
    {
        var response = await Create(5);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task TestCreateSizeSix()
    {
        var response = await Create(6);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task TestCreateSizeSeven()
    {
        var response = await Create(7);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task TestCreateSizeEight()
    {
        var response = await Create(8);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task TestCreateSizeNine()
    {
        var response = await Create(9);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task TestCreateSizeTen()
    {
        var response = await Create(10);
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    // FAIL

    [Test]
    public async Task TestCreateSizeTwo()
    {
        var response = await Create(2);
        Assert.That(response.IsSuccessStatusCode, Is.False);
    }

    [Test]
    public async Task TestCreateSizeEleven()
    {
        var response = await Create(11);
        Assert.That(response.IsSuccessStatusCode, Is.False);
    }
}