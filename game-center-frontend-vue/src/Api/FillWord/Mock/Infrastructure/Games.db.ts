import { IFillWord } from "@domain/FillWord/FillWord.models";

export type IFillWordDatabase = IFillWord & { wordsFoundIds: number[][] };
export const games: IFillWordDatabase[] = [];
