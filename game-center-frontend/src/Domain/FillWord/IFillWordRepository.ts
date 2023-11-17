import {FillWordGameStatus, IFillWordCreateModel, IFillWordModel} from "./FillWord.models";
import {ID} from "@domain/SharedKernel.types";

export interface IFillWordRepository {
    createFillWordGame: (model: IFillWordCreateModel) => Promise<IFillWordModel>,
    attempt: (arrayOfIds: ID[]) => Promise<FillWordGameStatus>
}