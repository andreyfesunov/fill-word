import {IFillWordApi} from "./FillWord.types";
import {IFillWordCreateModel} from "@domain/FillWord/FillWord.models";
import {FillWordCreateService} from "@api/FillWord/Mock/Services/FillWordCreateService";

export const getFillWordMockApi = (): IFillWordApi => <IFillWordApi>({
    createFillWordGame: (model: IFillWordCreateModel) => {
        return new Promise(resolve => resolve(FillWordCreateService.makeGame(model.size)));
    }
})