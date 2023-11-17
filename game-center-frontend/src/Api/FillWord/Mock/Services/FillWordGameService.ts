import {FillWordGameModel, FillWordGameStatus} from "@domain/FillWord/FillWord.models";

export class FillWordGameService {
    public checkProgress(model: FillWordGameModel, itemsIds: number[]): FillWordGameStatus {
        for (const wordIds of model.wordsIds) {
            let hasError: boolean = false;

            if (wordIds.length !== itemsIds.length) {
                hasError = true;
            }
            for (let i = 0; i < Math.min(wordIds.length, itemsIds.length); i++) {
                if (wordIds[i] !== itemsIds[i]) {
                    hasError = true;
                    break;
                }
            }

            if (!hasError) {
                model.wordsFoundIds.push([...itemsIds]);
                return this.checkIsGameFinished(model);
            }
        }

        return FillWordGameStatus.WRONG_MOVE;
    }

    private checkIsGameFinished(model: FillWordGameModel): FillWordGameStatus {
        if (model.wordsFoundIds.length !== model.wordsIds.length) return FillWordGameStatus.GOOD_MOVE;

        model.endDate = new Date();
        return FillWordGameStatus.END_GAME;
    }
}