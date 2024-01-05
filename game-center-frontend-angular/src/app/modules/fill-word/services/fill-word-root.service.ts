import {Injectable} from "@angular/core";
import {Subject} from "rxjs";

export enum FillWordEventType {
  Attempt = "Attempt",
  Create = "Create"
}

export interface IFillWordEvent {
  type: FillWordEventType
}

@Injectable()
export class FillWordRootService {
  public readonly event$: Subject<IFillWordEvent> = new Subject<IFillWordEvent>();
}
