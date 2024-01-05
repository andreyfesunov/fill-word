import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
import {AuthService} from "../services/auth.service";
import {RouterService} from "../services/router.service";

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private readonly _authService: AuthService, private readonly _routerService: RouterService) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = this._addToken(request, this._authService.GetToken());
    
    return next.handle(request).pipe(
      catchError((error) => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          this._authService.DoLogOut();
          this._routerService.toAuth();
        }
        return throwError(error);
      })
    );
  }

  private _addToken(request: HttpRequest<any>, token: string | null) {
    return request.clone(token ? {
      setHeaders: {
        UserId: token
      }
    } : {});
  }
}
