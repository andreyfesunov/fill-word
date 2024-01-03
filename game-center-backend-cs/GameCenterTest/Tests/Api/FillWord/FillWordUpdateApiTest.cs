using System.Text;
using game_center_backend_cs.Domain.DTOs.Requests;
using game_center_backend_cs.Domain.DTOs.Responses;
using game_center_backend_cs.Domain.Enums;
using game_center_backend_cs.Domain.Models.FillWord;
using Newtonsoft.Json;

namespace GameCenterTest.Tests.Api.FillWord;

[TestFixture]
public class FillWordUpdateApiTest : ApiTestBase
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

    private async Task<HttpResponseMessage> Attempt(string id, List<int> answerIds)
    {
        var httpContent = new FillWordAttemptRequest
        {
            Id = id,
            AnswerIds = answerIds
        };
        var json = JsonConvert.SerializeObject(httpContent);

        // Создание HTTP-запроса
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/FillWord");
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        // Выполнение PUT-запроса
        return await HttpClient.SendAsync(request);
    }

    private T Deserialize<T>(string json)
    {
        var model = JsonConvert.DeserializeObject<T>(json);

        if (model == null) throw new JsonSerializationException();

        return model;
    }

    [Test]
    public async Task TestGoodMove()
    {
        var createResponse = await Create(10);
        var json = await createResponse.Content.ReadAsStringAsync();
        var model = Deserialize<FillWordModel>(json);

        var updateResponse = await Attempt(model.Id, model.Answers.First());
        json = await updateResponse.Content.ReadAsStringAsync();
        var attemptModel = Deserialize<FillWordAttemptResponse>(json);

        Assert.That(attemptModel.Status, Is.EqualTo(FillWordAttemptStatusEnum.GoodMove));
    }

    [Test]
    public async Task TestWrongMove()
    {
        var createResponse = await Create(10);
        var json = await createResponse.Content.ReadAsStringAsync();
        var model = Deserialize<FillWordModel>(json);

        var updateResponse = await Attempt(model.Id, new List<int> { 0 });
        json = await updateResponse.Content.ReadAsStringAsync();
        var attemptModel = Deserialize<FillWordAttemptResponse>(json);

        Assert.That(attemptModel.Status, Is.EqualTo(FillWordAttemptStatusEnum.WrongMove));
    }

    [Test]
    public async Task TestEndGame()
    {
        var createResponse = await Create(10);
        var json = await createResponse.Content.ReadAsStringAsync();
        var model = Deserialize<FillWordModel>(json);

        var attemptModel = new FillWordAttemptResponse { Status = FillWordAttemptStatusEnum.WrongMove };
        foreach (var answer in model.Answers)
        {
            var updateResponse = await Attempt(model.Id, answer);
            json = await updateResponse.Content.ReadAsStringAsync();
            attemptModel = Deserialize<FillWordAttemptResponse>(json);
        }

        Assert.That(attemptModel.Status, Is.EqualTo(FillWordAttemptStatusEnum.EndGame));
    }
}