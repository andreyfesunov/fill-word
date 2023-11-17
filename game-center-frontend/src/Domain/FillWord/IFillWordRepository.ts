import {IFillWordCreateModel, IFillWordModel} from "./FillWord.models";

export interface IFillWordRepository {
    createFillWordGame: (model: IFillWordCreateModel) => Promise<IFillWordModel>
}