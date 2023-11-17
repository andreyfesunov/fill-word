import {ILocalStorageApi} from "@api/LocalStorage/LocalStorage.types";
import {LocalStorageRepository} from "@domain/LocalStorage/LocalStorage.repository";

export const getLocalStorageRepository = (
    localStorageApi: ILocalStorageApi,
): LocalStorageRepository => ({
    isSupported: () => localStorageApi.isSupported(),
    getItem: (key) => localStorageApi.getItem(key),
    setItem: (key, value) => localStorageApi.setItem(key, value),
    removeItem: (key) => localStorageApi.removeItem(key),
});