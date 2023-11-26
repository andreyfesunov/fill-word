import { getLocalStorageApi } from "@api/LocalStorage/LocalStorage.api";
import { getLocalStorageRepository } from "@repo/LocalStorage/LocalStorage.repository";
import {
  getItemUseCase,
  isSupportedUseCase,
  removeItemUseCase,
  setItemUseCase,
} from "@domain/LocalStorage/LocalStorage.use-cases";

// apis
const localStorageApi = getLocalStorageApi();

// repositories
const localStorageRepository = getLocalStorageRepository(localStorageApi);

export const localStorageModule = {
  getItem: getItemUseCase(localStorageRepository).execute,
  setItem: setItemUseCase(localStorageRepository).execute,
  removeItem: removeItemUseCase(localStorageRepository).execute,
  isSupported: isSupportedUseCase(localStorageRepository).execute,
};
