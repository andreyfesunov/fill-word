import {Injectable} from "@angular/core";
import {BehaviorSubject} from "rxjs";

@Injectable({providedIn: 'root'})
export class AuthStorageService {
  public readonly token$ = new BehaviorSubject<string | null>(null)
  private readonly tokenKey: string = "UserId";

  constructor() {
    const token = this.GetToken();
    if (token !== null) {
      this.SetToken(token);
    }
  }

  public GetToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  public SetToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
    this.token$.next(token);
  }

  public DeleteToken(): void {
    localStorage.removeItem(this.tokenKey);
    this.token$.next(null);
  }
}
