import {Router} from "@angular/router";
import {AppRoutes} from "../../app-routing.module";
import {Injectable} from "@angular/core";

const toAuth = [`${AppRoutes.Auth}`];
const toFillWord = [`${AppRoutes.FillWord}`];

@Injectable({providedIn: 'root'})
export class RouterService {
  constructor(private readonly _router: Router) {
  }

  public toAuth(): void {
    this._router.navigate(toAuth);
  }

  public toFillWord(): void {
    this._router.navigate(toFillWord);
  }

  public toGameFillWord(id: string): void {
    this._router.navigate([...toFillWord, id]);
  }
}
