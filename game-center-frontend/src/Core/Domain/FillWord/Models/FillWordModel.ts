import {FILL_WORD_DEFAULT_CONTENT, FillWordElementModel} from "./FillWordElementModel";

export class FillWordModel {
    matrix: FillWordElementModel[][];
    wordsIds: number[][] = [];

    constructor(public row: number, public col: number) {
        let id: number = 0;
        this.matrix = [...Array(row).keys()].map(() =>
            [...Array(col).keys()].map(() => new FillWordElementModel(id++, FILL_WORD_DEFAULT_CONTENT)));
    }

    public getWordsCount(): number {
        return this.wordsIds.length;
    }
}