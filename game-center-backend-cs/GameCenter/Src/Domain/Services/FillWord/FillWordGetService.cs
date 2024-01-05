using game_center_backend_cs.Domain.DTOs.Responses;
using game_center_backend_cs.Domain.Mappers;
using game_center_backend_cs.Domain.Models.UserFillWord;
using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Domain.Services.User;

namespace game_center_backend_cs.Domain.Services.FillWord;

public class FillWordGetService
{
    private readonly IFillWordRepository _fillWordRepository;
    private readonly IUserFillWordRepository _userFillWordRepository;

    public FillWordGetService(IFillWordRepository repository, IUserFillWordRepository userFillWordRepository)
    {
        _fillWordRepository = repository;
        _userFillWordRepository = userFillWordRepository;
    }

    /**
     * I think it's bad practice to use mappers in domain layer, but it's the only place i need it
     */
    public FillWordDetailResponse FindById(string id)
    {
        var user = AuthContext.GetCurrentUser();
        var model = _fillWordRepository.FindById(id);
        var relationModel = GetRelationModel(user.Id, model.Id);

        return FillWordMapper.ToDetailResponse(model, relationModel);
    }

    public List<FillWordDetailResponse> List()
    {
        var user = AuthContext.GetCurrentUser();
        var models = _fillWordRepository.List();
        var response = new List<FillWordDetailResponse>();

        foreach (var model in models)
        {
            var relationModel = GetRelationModel(user.Id, model.Id);
            response.Add(FillWordMapper.ToDetailResponse(model, relationModel));
        }

        return response;
    }

    private UserFillWordModel GetRelationModel(string userId, string fillWordId)
    {
        try
        {
            return _userFillWordRepository.Find(userId, fillWordId);
        }
        catch (InvalidOperationException)
        {
            return _userFillWordRepository.Create(new UserFillWordModel(
                null,
                userId,
                fillWordId
            ));
        }
    }
}