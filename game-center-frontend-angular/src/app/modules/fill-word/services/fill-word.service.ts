import {Injectable} from "@angular/core";
import {FillWordEventType, FillWordRootService} from "./fill-word-root.service";
import {concatWith, Observable, of, switchMap, tap} from "rxjs";
import {
  IFillWord,
  IFillWordAttemptRequest,
  IFillWordAttemptResponse,
  IFillWordCreateRequest
} from "../models/fill-word";
import {FillWordApiService} from "./fill-word-api.service";

@Injectable()
export class FillWordService {
  constructor(
    private readonly rootService: FillWordRootService,
    private readonly apiService: FillWordApiService
  ) {
  }

  public FindById(id: string): Observable<IFillWord> {
    return of(0).pipe(
      concatWith(this.rootService.event$),
      switchMap(() => this.apiService.FindById(id))
    )
  }

  public Attempt(request: IFillWordAttemptRequest): Observable<IFillWordAttemptResponse> {
    return this.apiService.Attempt(request).pipe(
      tap(() => {
        this.rootService.event$.next({
          type: FillWordEventType.Attempt
        })
      })
    );
  }

  public List(): Observable<IFillWord[]> {
    return of(0).pipe(
      concatWith(this.rootService.event$),
      switchMap(() => this.apiService.List())
    )
  }

  public Create(request: IFillWordCreateRequest): Observable<IFillWord> {
    return this.apiService.Create(request).pipe(
      tap(() => this.rootService.event$.next({
        type: FillWordEventType.Create
      }))
    );
  }
}
