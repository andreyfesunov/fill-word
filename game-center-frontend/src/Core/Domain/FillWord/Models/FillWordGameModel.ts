import {FillWordModel} from "./FillWordModel";
import {Nullable} from "../../../shared-kernel";

export class FillWordGameModel extends FillWordModel {
    public wordsFound = 0;
    public startDate: Date = new Date();
    public endDate: Nullable<Date> = null;

    protected constructor(public row: number, public col: number) {
        super(row, col);
    }

    public static createFromBaseModel(model: FillWordModel): this {
        const newModel = new FillWordGameModel(model.row, model.col);
        newModel.matrix = model.matrix;
        newModel.wordsIds = model.wordsIds;
        return newModel;
    }
}