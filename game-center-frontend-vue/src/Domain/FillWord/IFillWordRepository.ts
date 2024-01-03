import {
  FillWordGameStatus,
  IFillWord,
  IFillWordAttemptRequest, IFillWordAttemptResponse,
  IFillWordCreateRequest
} from "./FillWord.models";

export interface IFillWordRepository {
  createFillWordGame: (model: IFillWordCreateRequest) => Promise<IFillWord>;
  attempt: (
    model: IFillWordAttemptRequest
  ) => Promise<IFillWordAttemptResponse>;
}
