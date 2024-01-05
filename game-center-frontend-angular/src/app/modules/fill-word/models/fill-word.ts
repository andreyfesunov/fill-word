export interface IFillWord {
  id: string;
  matrix: IFillWordElement[][];
  foundAnswers: number[][];
}

export interface IFillWordGame {
  id: string;
  matrix: IFillWordGameElement[];
}

export interface IFillWordElement {
  id: number;
  content: string;
}

export interface IFillWordGameElement extends IFillWordElement {
  active: boolean;
}

export enum FillWordUserStatus {
  NOT_STARTED = 'NOT_STARTED',
  IN_PROGRESS = 'IN_PROGRESS',
  FINISHED = 'FINISHED'
}

// DTOs

export interface IFillWordAttemptRequest {
  id: string;
  answerIds: number[];
}

export interface IFillWordAttemptResponse {
  status: FillWordAttemptStatusEnum
}

export interface IFillWordCreateRequest {
  size: number;
}

export enum FillWordAttemptStatusEnum {
  WrongMove = 0,
  GoodMove = 1,
  EndGame = 2
}
