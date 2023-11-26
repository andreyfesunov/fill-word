import {
  UseCaseWithoutParams,
  UseCaseWithSingleParam,
} from "../UseCases.types";
import { SetItemParams } from "./LocalStorage.models";
import { ILocalStorageRepository } from "./ILocalStorageRepository";

// isSupportedUseCase
export type IsSupportedUseCase = UseCaseWithoutParams<boolean>;

export const isSupportedUseCase = (
  localStorageRepository: ILocalStorageRepository
): IsSupportedUseCase => ({
  execute: () => localStorageRepository.isSupported(),
});

// setItemUseCase
export type SetItemUseCase = UseCaseWithSingleParam<SetItemParams, void>;

export const setItemUseCase = (
  localStorageRepository: ILocalStorageRepository
): SetItemUseCase => ({
  execute: (params) => {
    if (!localStorageRepository.isSupported()) {
      return;
    }

    localStorageRepository.setItem(params.key, params.value);
  },
});

// getItemUseCase
export type GetItemUseCase = UseCaseWithSingleParam<string, string | null>;

export const getItemUseCase = (
  localStorageRepository: ILocalStorageRepository
): GetItemUseCase => ({
  execute: (key) => {
    if (!localStorageRepository.isSupported()) {
      return null;
    }

    return localStorageRepository.getItem(key);
  },
});

// removeItemUseCase
export type RemoveItemUseCase = UseCaseWithSingleParam<string, void>;

export const removeItemUseCase = (
  localStorageRepository: ILocalStorageRepository
): RemoveItemUseCase => ({
  execute: (key) => {
    if (!localStorageRepository.isSupported()) {
      return;
    }

    localStorageRepository.removeItem(key);
  },
});
