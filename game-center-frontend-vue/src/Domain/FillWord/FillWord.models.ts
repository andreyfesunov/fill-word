import { ID } from "../SharedKernel.types";

export interface IFillWordCeil {
  id: ID;
  content: string;
}

export interface IFillWord {
  id: ID;
  matrix: IFillWordCeil[][];
  wordsIds: ID[][];
  row: number;
  col: number;
}

export interface IFillWordGameElement extends IFillWordCeil {
  active: boolean;
}

export enum FillWordGameStatus {
  WRONG_MOVE = 0,
  GOOD_MOVE = 1,
  END_GAME = 2,
}

export interface IFillWordCreate {
  size: number;
}

export interface IFillWordAttempt {
  id: ID;
  ids: ID[];
}

export interface IFillWordGame extends IFillWord {
  matrix: IFillWordGameElement[][];
}
