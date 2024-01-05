import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
  ViewEncapsulation
} from "@angular/core";
import {IFillWordAttemptRequest, IFillWordGame, IFillWordGameElement} from "../../../../models/fill-word";

@Component({
  selector: 'app-fill-word-field',
  templateUrl: 'fill-word-field.component.html',
  styleUrls: ['fill-word-field.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FillWordFieldComponent implements OnChanges {
  @Input() model!: IFillWordGame;
  @Output() attempt: EventEmitter<IFillWordAttemptRequest> = new EventEmitter<IFillWordAttemptRequest>();
  private _draw = false;
  private _line: number[] = [];

  ngOnChanges(changes: SimpleChanges) {
    if (changes["model"]) {
      this._line = [];
    }
  }

  // Getters

  public GetSize(): number {
    return Math.sqrt(this.model.matrix.length);
  }

  public get GridClass(): string {
    return "fill-word-field-" + this.GetSize().toString();
  }

  private GetCeilById(id: number): IFillWordGameElement {
    const ceil = this.model.matrix.find((el) => el.id === id);
    if (ceil !== undefined) return ceil;
    throw new Error('No ceil with given id in matrix');
  }

  private GetCeilCoords(id: number): { row: number, ceil: number } {
    const pos = this.model.matrix.map((el) => el.id).indexOf(id);
    return {
      row: Math.trunc(pos / this.GetSize()),
      ceil: pos % this.GetSize()
    }
  }

  private GetPrevCeilId(): number | null {
    return this._line[this._line.length - 2];
  }

  private GetLastCeilId(): number {
    return this._line[this._line.length - 1];
  }

  // DOM actions

  public OnMouseUp(): void {
    if (!this._draw) return;

    this._draw = false;

    if (this._line.length !== 0) {
      this.attempt.emit({
        id: this.model.id,
        answerIds: this._line,
      });
    }
  }

  public OnMouseDown(id: number): void {
    this._draw = true;
    if (this.IsActive(id)) return;
    this.Activate(id);
  }

  public OnMouseOver(id: number): void {
    if (!this._draw) {
      return;
    }

    if (
      !this.IsActive(id) &&
      this.LastCeilLengthEqualOneCeil(id)
    ) {
      this.Activate(id);
    } else {
      if (this.IsPrevCeil(id)) {
        const lastCeilId: number = this.GetLastCeilId();
        this.Disable(lastCeilId);
      }
    }
  }

  // Others

  private IsActive(id: number): boolean {
    return this.GetCeilById(id).active;
  }

  private Activate(id: number): void {
    this.GetCeilById(id).active = true;
    this.AddTimeline(id);
  }

  private Disable(id: number): void {
    this.GetCeilById(id).active = false;
    this.RemoveLastMoveInTimeline();
  }

  private AddTimeline(id: number): void {
    this._line.push(id);
  }

  private RemoveLastMoveInTimeline(): void {
    this._line.splice(this._line.length - 1, 1);
  }

  private IsPrevCeil(id: number): boolean {
    if (!this.GetPrevCeilId()) return false;

    return this.GetPrevCeilId() === id;
  }

  private LastCeilLengthEqualOneCeil(id: number): boolean {
    const lastCeilId: number = this.GetLastCeilId();
    const lastCeilCoords = this.GetCeilCoords(lastCeilId);
    const coords = this.GetCeilCoords(id);

    return (
      ((lastCeilCoords.row === coords.row - 1 ||
          lastCeilCoords.row === coords.row + 1) &&
        lastCeilCoords.ceil === coords.ceil) ||
      ((lastCeilCoords.ceil === coords.ceil - 1 ||
          lastCeilCoords.ceil === coords.ceil + 1) &&
        lastCeilCoords.row === coords.row)
    );
  }
}
