import { UseCaseWithSingleParamAndPromiseResult } from "../UseCases.types";
import {
  IFillWord,
  IFillWordAttemptRequest,
  IFillWordAttemptResponse,
  IFillWordCreateRequest,
} from "./FillWord.models";
import { IFillWordRepository } from "./IFillWordRepository";

export type FillWordCreateGameUseCaseType =
  UseCaseWithSingleParamAndPromiseResult<IFillWordCreateRequest, IFillWord>;

export const FillWordCreateGameUseCase = (
  fillWordRepository: IFillWordRepository
): FillWordCreateGameUseCaseType => ({
  execute: (model) => fillWordRepository.createFillWordGame(model),
});

export type FillWordAttemptUseCaseType = UseCaseWithSingleParamAndPromiseResult<
  IFillWordAttemptRequest,
  IFillWordAttemptResponse
>;

export const FillWordAttemptUseCase = (
  fillWordRepository: IFillWordRepository
): FillWordAttemptUseCaseType => {
  return {
    execute: (model) => fillWordRepository.attempt(model),
  };
};
