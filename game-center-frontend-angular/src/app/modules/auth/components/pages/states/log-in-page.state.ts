import {Injectable, OnDestroy} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ILogInRequest} from "../../../models/user";
import {AuthService} from "../../../../../core/services/auth.service";
import {Subscription} from "rxjs";
import {RouterService} from "../../../../../core/services/router.service";

@Injectable()
export class LogInPageState implements OnDestroy {
  private readonly _subscription: Subscription = new Subscription();
  public readonly FormGroup: FormGroup = new FormGroup({
    login: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required])
  });

  constructor(private readonly _authService: AuthService, private readonly _routerService: RouterService) {
  }

  public OnSubmit(): void {
    if (this.FormGroup.valid) {
      const request: ILogInRequest = {
        login: this.FormGroup.get('login')?.value,
        password: this.FormGroup.get('password')?.value
      };

      this._subscription.add(
        this._authService.LogIn(request).subscribe(() => this._routerService.toFillWord())
      );
    } else {
      this.FormGroup.markAllAsTouched();
    }
  }

  public ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }
}
