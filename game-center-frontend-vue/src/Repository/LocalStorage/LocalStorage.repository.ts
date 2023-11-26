import { ILocalStorageApi } from "@api/LocalStorage/LocalStorage.types";
import { ILocalStorageRepository } from "@domain/LocalStorage/ILocalStorageRepository";

export const getLocalStorageRepository = (
  localStorageApi: ILocalStorageApi
): ILocalStorageRepository => ({
  isSupported: () => localStorageApi.isSupported(),
  getItem: (key) => localStorageApi.getItem(key),
  setItem: (key, value) => localStorageApi.setItem(key, value),
  removeItem: (key) => localStorageApi.removeItem(key),
});
