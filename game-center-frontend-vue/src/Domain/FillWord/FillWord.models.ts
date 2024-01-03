import { ID } from "../SharedKernel.types";

export interface IFillWordCeil {
  id: ID;
  content: string;
}

export interface IFillWord {
  id: ID;
  matrix: IFillWordCeil[][];
  answers: ID[][];
}

export interface IFillWordGameElement extends IFillWordCeil {
  active: boolean;
}

export enum FillWordGameStatus {
  WRONG_MOVE = 0,
  GOOD_MOVE = 1,
  END_GAME = 2,
}

export interface IFillWordCreateRequest {
  size: number;
}

export interface IFillWordAttemptRequest {
  id: ID;
  answerIds: ID[];
}

export interface IFillWordAttemptResponse {
  status: FillWordGameStatus;
}

export interface IFillWordGame extends IFillWord {
  matrix: IFillWordGameElement[][];
}
