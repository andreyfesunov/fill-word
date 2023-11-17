import {UseCaseWithSingleParamAndPromiseResult} from "../UseCases.types";
import {IFillWordCreateModel, IFillWordModel} from "./FillWord.models";
import {IFillWordRepository} from "./IFillWordRepository";

export type FillWordCreateGameUseCaseType = UseCaseWithSingleParamAndPromiseResult<IFillWordCreateModel, IFillWordModel>

export const FillWordCreateGameUseCase = (fillWordRepository: IFillWordRepository): FillWordCreateGameUseCaseType => ({
    execute: (model) => fillWordRepository.createFillWordGame(model)
})