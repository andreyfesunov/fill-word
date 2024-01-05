import {Injectable, OnDestroy} from "@angular/core";
import {AuthStorageService} from "./auth-storage.service";
import {BehaviorSubject, Observable, Subscription, tap} from "rxjs";
import {ILogInRequest, ILogInResponse} from "../../modules/auth/models/user";
import {HttpClient} from "@angular/common/http";
import {Config} from "../config";

@Injectable({providedIn: 'root'})
export class AuthService implements OnDestroy {
  public readonly root: string = `${this._config.apiRoot}/User`;
  public readonly login$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(this._storage.GetToken() !== null);
  private readonly _subscription: Subscription = this._storage.token$.subscribe((v) => this.login$.next(v !== null));

  constructor(
    private readonly _storage: AuthStorageService,
    private readonly _httpClient: HttpClient,
    private readonly _config: Config
  ) {
  }

  public LogIn(request: ILogInRequest): Observable<ILogInResponse> {
    return this._httpClient.post<ILogInResponse>(this.root, request).pipe(
      tap((response) => this._storage.SetToken(response.id))
    );
  }

  public GetToken(): string | null {
    return this._storage.GetToken();
  }

  public DoLogOut(): void {
    this._storage.DeleteToken();
  }

  ngOnDestroy() {
    this._subscription.unsubscribe();
  }
}
