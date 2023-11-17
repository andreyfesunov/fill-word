import {ID, Nullable} from "../SharedKernel.types";

export interface IFillWordElementModel {
    id: ID,
    content: string
}

export interface IFillWordModel {
    matrix: IFillWordElementModel[][];
    wordsIds: ID[][];
    row: number;
    col: number;
}

export enum FillWordGameStatus {
    WRONG_MOVE = 0,
    GOOD_MOVE = 1,
    END_GAME = 2
}

export interface IFillWordCreateModel {
    size: number;
}

export class FillWordGameModel implements IFillWordModel {
    public wordsIds: number[][] = [];
    public wordsFoundIds: number[][] = [];
    public startDate: Date = new Date();
    public endDate: Nullable<Date> = null;
    public matrix: IFillWordElementModel[][] = [];

    public constructor(public row: number, public col: number) {
    }

    public static createFromBaseModel(model: IFillWordModel): FillWordGameModel {
        const newModel = new FillWordGameModel(model.row, model.col);

        newModel.matrix = model.matrix;
        newModel.wordsIds = model.wordsIds;

        return newModel;
    }
}