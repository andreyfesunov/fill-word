import { IFillWordApi } from "./FillWord.types";
import {
  IFillWord,
  IFillWordAttemptResponse,
  IFillWordCreateRequest,
} from "@domain/FillWord/FillWord.models";

const getRequestOptions: (body: object, method: string) => RequestInit = (
  body: object,
  method: string
) =>
  ({
    method: method,
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(body),
  } as RequestInit);

const backendApi = "http://localhost:5041/api/";
const controller = "FillWord";

export const getFillWordMockApi = (): IFillWordApi =>
  <IFillWordApi>{
    createFillWordGame: (model: IFillWordCreateRequest) => {
      return fetch(
        backendApi + controller,
        getRequestOptions(model, "PUT")
      ).then((response) => response.json()) as Promise<IFillWord>;
    },
    attempt: (model) => {
      return fetch(
        backendApi + controller,
        getRequestOptions(model, "POST")
      ).then((response) =>
        response.json()
      ) as Promise<IFillWordAttemptResponse>;
    },
  };
