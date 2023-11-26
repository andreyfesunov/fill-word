import {
  FillWordGameStatus,
  IFillWord,
  IFillWordAttempt,
  IFillWordCreate,
} from "./FillWord.models";

export interface IFillWordRepository {
  createFillWordGame: (model: IFillWordCreate) => Promise<IFillWord>;
  attempt: (model: IFillWordAttempt) => Promise<FillWordGameStatus>;
}
