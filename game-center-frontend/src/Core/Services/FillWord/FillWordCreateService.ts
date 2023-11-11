import {Utils} from "../Utils";
import {FILL_WORD_DEFAULT_CONTENT, FillWordElementModel} from "../../Domain/FillWord/Models/FillWordElementModel";
import {FillWordModel} from "../../Domain/FillWord/Models/FillWordModel";
import {Nullable} from "../../shared-kernel";

export class FillWordCreateService {
    public static CreateFillWordMatrix(row: number, col: number, words: string[]): FillWordModel {
        const hasCreationAttemptMap: boolean[] = Array(row * col).fill(false);
        const resultModel: FillWordModel = new FillWordModel(row, col);
        words = Utils.shuffle([...words]).map((word) => FILL_WORD_DEFAULT_CONTENT + word);

        for (const _ of Array(row * col)) {
            const randomValue = Utils.getRandomValueWithMap(hasCreationAttemptMap);
            const creationModel = new FillWordCreationModel(resultModel, words, null, Math.floor(randomValue / row), randomValue % col, 0);

            if (this.TryFillField(creationModel)) {
                break;
            }
        }

        this.MapSpecificData(resultModel);

        return resultModel;
    }

    private static MapSpecificData(model: FillWordModel): void {
        let flatMap = model.matrix.flat();

        while (flatMap.length !== 0) {
            let element = flatMap.filter((element) => element.getNext() !== null).pop();

            while (flatMap.filter((el) => el.getNext() === element.getId()).length !== 0) {
                element = flatMap.filter((el) => el.getNext() === element.getId()).pop();
            }

            const result: number[] = [];
            result.push(element.getId());
            while (element.getNext() !== null) {
                element = flatMap.filter((el) => el.getId() === element.getNext()).pop();
                result.push(element.getId());
            }

            model.wordsIds.push(result);
            flatMap = flatMap.filter((el) => result.indexOf(el.getId()) === -1);
        }
    }

    private static TryFillField(model: FillWordCreationModel): boolean {
        if (!this.IsMatrixFinished(model.getResultModel()))
            return true;

        const resultModel = model.getResultModel();
        const currentLetter = this.GetLetter(model.getWords(), model.getLevel());
        const currentElement = model.getCurrentElement();

        if (currentLetter === FILL_WORD_DEFAULT_CONTENT) {
            model.setPreviousModel(null);
            model.incrementLevel();
        }

        currentElement.setContent(this.GetLetter(model.getWords(), model.getLevel()));
        model.getPreviousModel()?.setNext(currentElement.getId());

        const moves: boolean[] = Array(4).fill(false);
        for (let i = 0; i < moves.length; i++) {
            const val: Path = Utils.getRandomValueWithMap(moves);
            const newModel: FillWordCreationModel = model.clone();
            newModel.setPreviousModel(currentElement);
            newModel.incrementLevel();

            switch (val) {
                case Path.TOP:
                    newModel.setCurrentRow(newModel.getCurrentRow() - 1);

                    if (this.CheckMove(newModel)) {
                        this.TryFillField(newModel);
                    }
                    break;
                case Path.RIGHT:
                    newModel.setCurrentCol(newModel.getCurrentCol() + 1);

                    if (this.CheckMove(newModel)) {
                        this.TryFillField(newModel);
                    }
                    break;
                case Path.BOTTOM:
                    newModel.setCurrentRow(newModel.getCurrentRow() + 1);

                    if (this.CheckMove(newModel)) {
                        this.TryFillField(newModel);
                    }
                    break;
                case Path.LEFT:
                    newModel.setCurrentCol(newModel.getCurrentRow() - 1);

                    if (this.CheckMove(newModel)) {
                        this.TryFillField(newModel);
                    }
                    break;
            }
        }

        if (!this.IsMatrixFinished(resultModel)) {
            return true;
        }

        currentElement.setContent(FILL_WORD_DEFAULT_CONTENT);
        currentElement.setNext(null);

        return false;
    }

    private static IsMatrixFinished(result: FillWordModel): boolean {
        for (let i = 0; i < result.row; i++) {
            for (let j = 0; j < result.col; j++) {
                if (result.matrix[i][j].getContent() === '#') {
                    return true;
                }
            }
        }

        return false;
    }

    private static CheckMove(model: FillWordCreationModel) {
        const currentRow = model.getCurrentRow();
        const currentCol = model.getCurrentCol();
        const res = model.getResultModel();

        return !(currentRow < 0 || currentRow == res.matrix.length || currentCol < 0 || currentCol == res.matrix[0].length || res.matrix[currentRow][currentCol].getContent() !== '#');
    }

    private static GetLetter(words: string[], pos: number): string {
        return words.map((el) => el.split('')).reduce((acc, cur) => acc.concat(cur))[pos];
    }
}

enum Path {
    TOP,
    RIGHT,
    BOTTOM,
    LEFT
}

class FillWordCreationModel {
    constructor(
        private result: FillWordModel,
        private words: string[],
        private previous: Nullable<FillWordElementModel>,
        private currentRow: number,
        private currentCol: number,
        private level: number
    ) {
    }

    public clone(): FillWordCreationModel {
        return new FillWordCreationModel(
            this.result,
            this.words,
            this.previous,
            this.currentRow,
            this.currentCol,
            this.level
        );
    }

    public getResultModel(): FillWordModel {
        return this.result;
    }

    public getWords(): string[] {
        return this.words;
    }

    // ****

    public getLevel(): number {
        return this.level;
    }

    public getCurrentRow(): number {
        return this.currentRow;
    }

    public setCurrentRow(v: number): this {
        this.currentRow = v;
        return this;
    }

    public getCurrentCol(): number {
        return this.currentCol;
    }

    public setCurrentCol(v: number): this {
        this.currentCol = v;
        return this;
    }

    public getPreviousModel(): Nullable<FillWordElementModel> {
        return this.previous;
    }

    public setPreviousModel(value: Nullable<FillWordElementModel>): this {
        this.previous = value;
        return this;
    }

    // ****

    public getCurrentElement(): FillWordElementModel {
        return this.result.matrix[this.currentRow][this.currentCol];
    }

    public incrementLevel(): this {
        this.level++;
        return this;
    }
}