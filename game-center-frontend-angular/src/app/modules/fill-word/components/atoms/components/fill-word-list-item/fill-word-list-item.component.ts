import {ChangeDetectionStrategy, Component, Input, ViewEncapsulation} from "@angular/core";
import {FillWordUserStatus} from "../../../../models/fill-word";

@Component({
  selector: 'app-fill-word-list-item',
  templateUrl: 'fill-word-list-item.component.html',
  styleUrls: ['fill-word-list-item.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FillWordListItemComponent {
  @Input() number!: number;
  @Input() status!: FillWordUserStatus;
  @Input() size!: number;

  public get GetStatusClass(): string {
    switch (this.status) {
      case FillWordUserStatus.NOT_STARTED:
        return 'fill-word-list-item__status--not-started';
      case FillWordUserStatus.IN_PROGRESS:
        return 'fill-word-list-item__status--in-progress';
      case FillWordUserStatus.FINISHED:
        return 'fill-word-list-item__status--finished';
    }
  }
}
