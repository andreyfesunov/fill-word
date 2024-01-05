import {Injectable, OnDestroy} from "@angular/core";
import {map, Observable, Subscription} from "rxjs";
import {IFillWord, IFillWordCreateRequest, IFillWordGame} from "../../../models/fill-word";
import {FillWordService} from "../../../services/fill-word.service";
import {RouterService} from "../../../../../core/services/router.service";

@Injectable()
export class FillWordAllPageState implements OnDestroy {
  public readonly models$: Observable<IFillWordGame[]>;
  private readonly _subscription: Subscription = new Subscription();

  constructor(private readonly _service: FillWordService, private readonly _routerService: RouterService) {
    this.models$ = this._service.List()
      .pipe(
        map((models) => models.map((model) => this.ToGameModel(model)))
      )
  }

  ngOnDestroy(): void {
  }

  public OnCreate(request: IFillWordCreateRequest): void {
    this._subscription.add(
      this._service.Create(request).subscribe((model) => this._routerService.toGameFillWord(model.id))
    )
  }

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
