using game_center_backend_cs.Domain.Enums;
using game_center_backend_cs.Domain.Repositories;

namespace game_center_backend_cs.Domain.Services.FillWord;

public class FillWordUpdateService
{
    private readonly IFillWordRepository _fillWordRepository;

    public FillWordUpdateService(IFillWordRepository repository)
    {
        _fillWordRepository = repository;
    }

    public FillWordAttemptStatusEnum Attempt(string id, List<int> answerIds)
    {
        var model = _fillWordRepository.FindById(id);
        FillWordSecurityService.ValidateAttemptAnswers(model, answerIds);
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
            model.FoundAnswers.Add(answerIds);
            _fillWordRepository.Update(model);

            return model.FoundAnswers.Count == model.Answers.Count
                ? FillWordAttemptStatusEnum.EndGame
                : FillWordAttemptStatusEnum.GoodMove;
        }

        return FillWordAttemptStatusEnum.WrongMove;
    }
}