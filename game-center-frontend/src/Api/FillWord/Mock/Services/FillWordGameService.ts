import {FillWordGameModel, FillWordGameStatus, IFillWordAttemptModel} from "@domain/FillWord/FillWord.models";

export class FillWordGameService {
    public static checkProgress(dto: IFillWordAttemptModel): FillWordGameStatus {
        for (const wordIds of dto.model.wordsIds) {
            let hasError: boolean = false;

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
                dto.model.wordsFoundIds.push([...dto.ids]);
                return this.checkIsGameFinished(dto.model);
            }
        }

        return FillWordGameStatus.WRONG_MOVE;
    }

    private static checkIsGameFinished(model: FillWordGameModel): FillWordGameStatus {
        if (model.wordsFoundIds.length !== model.wordsIds.length) return FillWordGameStatus.GOOD_MOVE;

        return FillWordGameStatus.END_GAME;
    }
}