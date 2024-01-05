import {ChangeDetectionStrategy, Component, EventEmitter, Input, Output, ViewEncapsulation} from "@angular/core";
import {IFillWordCreateRequest, IFillWordGame} from "../../../../models/fill-word";

@Component({
  selector: 'app-fill-word-all-board-with-creation',
  templateUrl: 'fill-word-all-board-with-creation.component.html',
  styleUrls: ['fill-word-all-board-with-creation.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FillWordAllBoardWithCreationComponent {
  @Input() models!: IFillWordGame[];
  @Output() create: EventEmitter<IFillWordCreateRequest> = new EventEmitter<IFillWordCreateRequest>();
  public readonly availableSizes = [3, 4, 5, 6, 7, 8, 9, 10];
  public selectedSize = 3;

  public OnCreate(): void {
    this.create.emit({
      size: this.selectedSize
    });
  }
}
