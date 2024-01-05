import {ChangeDetectionStrategy, Component, Input, ViewEncapsulation} from "@angular/core";
import {FillWordUserStatus, IFillWordGame, IFillWordGameElement} from "../../../../models/fill-word";
import {RouterService} from "../../../../../../core/services/router.service";

@Component({
  selector: 'app-fill-word-list-table',
  styleUrls: ['fill-word-list-table.component.scss'],
  templateUrl: 'fill-word-list-table.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class FillWordListTableComponent {
  @Input() models!: IFillWordGame[];

  constructor(private readonly _routerService: RouterService) {
  }

  public GetSize(list: IFillWordGameElement[]): number {
    return Math.sqrt(list.length);
  }

  public GetStatus(list: IFillWordGameElement[]): FillWordUserStatus {
    const activeMap = list.map((el) => el.active);

    if (activeMap.indexOf(false) === -1) {
      return FillWordUserStatus.FINISHED;
    } else if (activeMap.indexOf(true) === -1) {
      return FillWordUserStatus.NOT_STARTED;
    } else {
      return FillWordUserStatus.IN_PROGRESS;
    }
  }

  public OnClick(id: string): void {
    this._routerService.toGameFillWord(id);
  }
}
