import {map, Observable, Subscription, switchMap, tap} from "rxjs";
import {ActivatedRoute} from "@angular/router";
import {RouteParams} from "../../../../../core/config";
import {FillWordService} from "../../../services/fill-word.service";
import {filterTruthy} from "../../../../../core/utils/filterTruthy";
import {FillWordAttemptStatusEnum, IFillWord, IFillWordAttemptRequest, IFillWordGame} from "../../../models/fill-word";
import {Injectable, OnDestroy} from "@angular/core";
import {RouterService} from "../../../../../core/services/router.service";

@Injectable()
export class FillWordGamePageState implements OnDestroy {
  public readonly model$: Observable<IFillWordGame>;
  private readonly _subscription: Subscription = new Subscription();
  private _isGameFinished: boolean = false;

  constructor(
    private readonly _service: FillWordService,
    private readonly _route: ActivatedRoute,
    private readonly _routerService: RouterService
  ) {
    this.model$ = this._route.paramMap.pipe(
      map((map) => map.get(RouteParams.Id)),
      filterTruthy(),
      switchMap((id) => this._service.FindById(id)),
      map((model) => this.ToGameModel(model)),
      tap((model) => {
        this._isGameFinished = model.matrix.map((el) => el.active).indexOf(false) === -1;
      })
    )
  }

  // Getters

  public get IsGameFinished(): boolean {
    return this._isGameFinished;
  }

  // Hooks

  public ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }

  public OnAttempt(request: IFillWordAttemptRequest): void {
    if (!this.IsGameFinished) {
      this._subscription.add(
        this._service.Attempt(request).subscribe((response) => {
          if (response.status === FillWordAttemptStatusEnum.EndGame) {
            this._routerService.toFillWord();
          }
        })
      );
    }
  }

  // Mappers

  private ToGameModel(model: IFillWord): IFillWordGame {
    const foundAnswers = model.foundAnswers.flat();
    return {
      id: model.id,
      matrix: model.matrix.flat().map((element) => ({
        id: element.id,
        content: element.content,
        active: foundAnswers.includes(element.id)
      }))
    }
  }
}
