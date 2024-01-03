namespace GameCenterTest.Tests.Api;

public abstract class ApiTestBase
{
    protected readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("http://localhost:5041")
    };
}