import {IFillWordApi} from "@api/FillWord/FillWord.types";
import {IFillWordRepository} from "@domain/FillWord/IFillWordRepository";

export const getFillWordRepository = (fillWordApi: IFillWordApi): IFillWordRepository => ({
    createFillWordGame: async (model) => {
        return await fillWordApi.createFillWordGame(model);
    }
});