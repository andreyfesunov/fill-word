import {ID} from "../SharedKernel.types";

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

export interface IFillWordGameElementModel extends IFillWordElementModel {
    active: boolean;
}

export enum FillWordGameStatus {
    WRONG_MOVE = 0,
    GOOD_MOVE = 1,
    END_GAME = 2
}

export interface IFillWordCreateModel {
    size: number;
}

export interface IFillWordAttemptModel {
    model: FillWordGameModel; // IN REAL CASE THERE WILL BE ONLY ID OF GAME
    ids: ID[];
}

export class FillWordGameModel implements IFillWordModel {
    public wordsIds: number[][] = [];
    public wordsFoundIds: number[][] = [];
    public matrix: IFillWordGameElementModel[][] = [];

    public constructor(public row: number, public col: number) {
    }

    public static createFromBaseModel(model: IFillWordModel): FillWordGameModel {
        const newModel = new FillWordGameModel(model.row, model.col);

        newModel.matrix = model.matrix.map((row) => row.map((ceil) => ({
            content: ceil.content,
            id: ceil.id,
            active: false
        })));
        newModel.wordsIds = model.wordsIds;

        return newModel;
    }
}