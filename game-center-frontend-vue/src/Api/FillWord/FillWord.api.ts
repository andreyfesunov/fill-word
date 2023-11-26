import { IFillWordApi } from "./FillWord.types";
import { IFillWordCreate } from "@domain/FillWord/FillWord.models";
import { FillWordCreateService } from "@api/FillWord/Mock/Services/FillWordCreateService";
import { FillWordGameService } from "@api/FillWord/Mock/Services/FillWordGameService";

export const getFillWordMockApi = (): IFillWordApi =>
  <IFillWordApi>{
    createFillWordGame: (model: IFillWordCreate) => {
      return new Promise((resolve) =>
        resolve(FillWordCreateService.makeGame(model.size))
      );
    },
    attempt: (model) => {
      return new Promise((resolve) =>
        resolve(FillWordGameService.checkProgress(model))
      );
    },
  };
