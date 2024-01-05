using game_center_backend_cs.Domain.Enums;
using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Domain.Services.User;

namespace game_center_backend_cs.Domain.Services.FillWord;

public class FillWordUpdateService
{
    private readonly IFillWordRepository _fillWordRepository;
    private readonly IUserFillWordRepository _userFillWordRepository;

    public FillWordUpdateService(IFillWordRepository repository, IUserFillWordRepository userFillWordRepository)
    {
        _fillWordRepository = repository;
        _userFillWordRepository = userFillWordRepository;
    }

    public FillWordAttemptStatusEnum Attempt(string id, List<int> answerIds)
    {
        var user = AuthContext.GetCurrentUser();
        var model = _fillWordRepository.FindById(id);
        var relationModel = _userFillWordRepository.Find(user.Id, model.Id);
        FillWordSecurityService.ValidateAttemptAnswers(relationModel, answerIds);
        // ----

        foreach (var answer in model.Answers)
        {
            var equals = true;
            for (var i = 0; i < Math.Min(answer.Count, answerIds.Count); i++)
                if (answer[i] != answerIds[i] || answerIds.Count != answer.Count)
                {
                    equals = false;
                    break;
                }

            if (!equals) continue;
            relationModel.FoundAnswers.Add(answerIds);
            _userFillWordRepository.Update(relationModel);

            return relationModel.FoundAnswers.Count == model.Answers.Count
                ? FillWordAttemptStatusEnum.EndGame
                : FillWordAttemptStatusEnum.GoodMove;
        }

        return FillWordAttemptStatusEnum.WrongMove;
    }
}