import {UseCaseWithSingleParamAndPromiseResult} from "../UseCases.types";
import {FillWordGameStatus, IFillWordCreateModel, IFillWordModel} from "./FillWord.models";
import {IFillWordRepository} from "./IFillWordRepository";
import {ID} from "@domain/SharedKernel.types";
import {ILocalStorageRepository} from "@domain/LocalStorage/ILocalStorageRepository";

export type FillWordCreateGameUseCaseType = UseCaseWithSingleParamAndPromiseResult<IFillWordCreateModel, IFillWordModel>

export const FillWordCreateGameUseCase = (fillWordRepository: IFillWordRepository, storageRepository: ILocalStorageRepository): FillWordCreateGameUseCaseType => ({
    execute: (model) => {
        const modelPromise = fillWordRepository.createFillWordGame(model);

        modelPromise.then(() => {
            storageRepository.setItem('start', new Date().getTime().toString());
        })

        return modelPromise;
    }
})

export type FillWordAttemptUseCaseType = UseCaseWithSingleParamAndPromiseResult<ID[], FillWordGameStatus>

export const FillWordAttemptUseCase = (fillWordRepository: IFillWordRepository, storageRepository: ILocalStorageRepository): FillWordAttemptUseCaseType => ({
    execute: (arrayOfIds) => {
        const statusPromise = fillWordRepository.attempt(arrayOfIds);

        statusPromise.then((status) => {
            if (status === FillWordGameStatus.END_GAME) {
                const startDate: number = parseInt(storageRepository.getItem('start') ?? new Date().getTime().toString());
                const endDate: number = new Date().getTime();
                storageRepository.setItem('end', (endDate - startDate).toString());
            }
        })

        return statusPromise;
    }
})