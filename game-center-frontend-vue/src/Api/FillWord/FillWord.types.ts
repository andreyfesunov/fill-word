import {
  FillWordGameStatus,
  IFillWord,
  IFillWordAttemptRequest, IFillWordAttemptResponse,
  IFillWordCreateRequest
} from "@domain/FillWord/FillWord.models";

export enum FillWordEndPoints {}

/*
    PLACE FOR YOUR ENDPOINTS ON BACKEND SIDE. I'M USING MOCK FOR API SERVER, SO THERE ARE NO CONTENT.
     */

export interface IFillWordApi {
  createFillWordGame: (model: IFillWordCreateRequest) => Promise<IFillWord>;
  attempt: (dto: IFillWordAttemptRequest) => Promise<IFillWordAttemptResponse>;
}
