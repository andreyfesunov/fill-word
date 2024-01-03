using game_center_backend_cs.Domain.Models.FillWord;

namespace game_center_backend_cs.Domain.Services.FillWord;

public static class FillWordSecurityService
{
    public static void ValidateAttemptAnswers(FillWordModel model, List<int> answerIds)
    {
        if (!IsAttemptAnswersCorrect(model, answerIds))
            throw new Exception("Given answer already exists in array of answers");
    }

    private static bool IsAttemptAnswersCorrect(FillWordModel model, List<int> answerIds)
    {
        foreach (var foundAnswer in model.FoundAnswers)
        {
            var hasError = true;
            for (var i = 0; i < Math.Min(foundAnswer.Count, answerIds.Count); i++)
                if (foundAnswer[i] != answerIds[i] || foundAnswer.Count != answerIds.Count)
                {
                    hasError = false;
                    break;
                }

            if (hasError) return false;
        }

        return true;
    }
}