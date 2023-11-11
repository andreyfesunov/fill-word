import {FillWordGameStatus} from "../../Domain/FillWord/Enums/FillWordGameStatus";
import {FillWordGameModel} from "../../Domain/FillWord/Models/FillWordGameModel";

export class FillWordGameService {
    public checkProgress(model: FillWordGameModel, itemsIds: number[]): FillWordGameStatus {
        for (const wordIds of model.wordsIds) {
            let hasError: boolean = false;
            for (let i = 0; i < Math.min(wordIds.length, itemsIds.length); i++) {
                if (wordIds[i] !== itemsIds[i]) {
                    hasError = true;
                    break;
                }
            }

            if (!hasError) {
                model.wordsFound++;
                return this.checkIsGameFinished(model);
            }
        }

        return FillWordGameStatus.WRONG_MOVE;
    }

    private checkIsGameFinished(model: FillWordGameModel): FillWordGameStatus {
        if (model.wordsFound !== model.getWordsCount()) return FillWordGameStatus.GOOD_MOVE;

        model.endDate = new Date();
        return FillWordGameStatus.END_GAME;
    }
}