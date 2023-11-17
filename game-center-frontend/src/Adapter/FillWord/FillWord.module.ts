import {getFillWordMockApi} from "@api/FillWord/FillWord.api";
import {getFillWordRepository} from "@repo/FillWord/FillWord.repository";
import {FillWordAttemptUseCase, FillWordCreateGameUseCase} from "@domain/FillWord/FillWord.use-cases";
import {getLocalStorageApi} from "@api/LocalStorage/LocalStorage.api";
import {getLocalStorageRepository} from "@repo/LocalStorage/LocalStorage.repository";

// apis
const fillWordApi = getFillWordMockApi();
const localStorageApi = getLocalStorageApi();

// repos
const fillWordRepository = getFillWordRepository(fillWordApi);
const localStorageRepository = getLocalStorageRepository(localStorageApi);

export const fillWordModule = {
    createGame: FillWordCreateGameUseCase(fillWordRepository, localStorageRepository).execute,
    attempt: FillWordAttemptUseCase(fillWordRepository, localStorageRepository).execute
}