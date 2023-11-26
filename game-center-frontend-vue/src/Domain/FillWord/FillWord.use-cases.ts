import { UseCaseWithSingleParamAndPromiseResult } from "../UseCases.types";
import {
  FillWordGameStatus,
  IFillWord,
  IFillWordAttempt,
  IFillWordCreate,
} from "./FillWord.models";
import { IFillWordRepository } from "./IFillWordRepository";

export type FillWordCreateGameUseCaseType =
  UseCaseWithSingleParamAndPromiseResult<IFillWordCreate, IFillWord>;

export const FillWordCreateGameUseCase = (
  fillWordRepository: IFillWordRepository
): FillWordCreateGameUseCaseType => ({
  execute: (model) => fillWordRepository.createFillWordGame(model),
});

export type FillWordAttemptUseCaseType = UseCaseWithSingleParamAndPromiseResult<
  IFillWordAttempt,
  FillWordGameStatus
>;

export const FillWordAttemptUseCase = (
  fillWordRepository: IFillWordRepository
): FillWordAttemptUseCaseType => {
  return {
    execute: (model) => fillWordRepository.attempt(model),
  };
};
