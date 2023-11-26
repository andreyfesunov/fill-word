import {
  FillWordGameStatus,
  IFillWordAttempt,
} from "@domain/FillWord/FillWord.models";
import {
  games,
  IFillWordDatabase,
} from "@api/FillWord/Mock/Infrastructure/Games.db";

export class FillWordGameService {
  public static checkProgress(dto: IFillWordAttempt): FillWordGameStatus {
    const model = games.find((v) => v.id === dto.id);
    if (model === undefined) {
      throw new Error("Not found model");
    }

    for (const wordIds of model.wordsIds) {
      let hasError = false;

      if (wordIds.length !== dto.ids.length) {
        hasError = true;
      }
      for (let i = 0; i < Math.min(wordIds.length, dto.ids.length); i++) {
        if (wordIds[i] !== dto.ids[i]) {
          hasError = true;
          break;
        }
      }

      if (!hasError) {
        model.wordsFoundIds.push([...dto.ids]);
        return this.checkIsGameFinished(model);
      }
    }

    return FillWordGameStatus.WRONG_MOVE;
  }

  private static checkIsGameFinished(
    model: IFillWordDatabase
  ): FillWordGameStatus {
    if (model.wordsFoundIds.length !== model.wordsIds.length)
      return FillWordGameStatus.GOOD_MOVE;

    return FillWordGameStatus.END_GAME;
  }
}
