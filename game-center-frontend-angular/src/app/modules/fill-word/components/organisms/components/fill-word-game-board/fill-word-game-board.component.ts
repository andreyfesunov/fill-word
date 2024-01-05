import {ChangeDetectionStrategy, Component, EventEmitter, Input, Output, ViewEncapsulation} from "@angular/core";
import {IFillWordAttemptRequest, IFillWordGame} from "../../../../models/fill-word";
import {RouterService} from "../../../../../../core/services/router.service";

@Component({
  selector: 'app-fill-word-game-board',
  templateUrl: 'fill-word-game-board.component.html',
  styleUrls: ['fill-word-game-board.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FillWordGameBoardComponent {
  @Input() model!: IFillWordGame;
  @Input() isGameFinished!: boolean;
  @Output() attempt: EventEmitter<IFillWordAttemptRequest> = new EventEmitter<IFillWordAttemptRequest>();

  public constructor(private readonly _routerService: RouterService) {
  }

  public GoBack(): void {
    this._routerService.toFillWord();
  }

  public OnAttempt(request: IFillWordAttemptRequest): void {
    this.attempt.emit(request);
  }
}
