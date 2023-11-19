import {FillWordGameStatus, IFillWordAttemptModel, IFillWordCreateModel, IFillWordModel} from "./FillWord.models";

export interface IFillWordRepository {
    createFillWordGame: (model: IFillWordCreateModel) => Promise<IFillWordModel>,
    attempt: (model: IFillWordAttemptModel) => Promise<FillWordGameStatus>
}