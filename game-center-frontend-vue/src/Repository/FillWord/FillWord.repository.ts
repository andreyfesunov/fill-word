import { IFillWordApi } from "@api/FillWord/FillWord.types";
import { IFillWordRepository } from "@domain/FillWord/IFillWordRepository";

export const getFillWordRepository = (
  fillWordApi: IFillWordApi
): IFillWordRepository => ({
  createFillWordGame: (model) => {
    return fillWordApi.createFillWordGame(model);
  },
  attempt: (model) => {
    return fillWordApi.attempt(model);
  },
});
