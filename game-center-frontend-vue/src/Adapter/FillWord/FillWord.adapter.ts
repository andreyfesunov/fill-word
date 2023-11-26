import { getFillWordMockApi } from "@api/FillWord/FillWord.api";
import { getFillWordRepository } from "@repo/FillWord/FillWord.repository";
import {
  FillWordAttemptUseCase,
  FillWordCreateGameUseCase,
} from "@domain/FillWord/FillWord.use-cases";

// apis
const fillWordApi = getFillWordMockApi();

// repos
const fillWordRepository = getFillWordRepository(fillWordApi);

export const fillWordAdapter = {
  createGame: FillWordCreateGameUseCase(fillWordRepository).execute,
  attempt: FillWordAttemptUseCase(fillWordRepository).execute,
};
