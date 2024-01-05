import {Injectable} from "@angular/core";

export enum RouteParams {
  Id = 'id'
}

@Injectable({
  providedIn: 'root'
})
export class Config {
  public readonly apiRoot = 'http://localhost:5041/api'
}
