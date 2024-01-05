import {Component, Input} from "@angular/core";

@Component({
  selector: 'app-fill-word-ceil',
  template: `
    <div class="fill-word-ceil" [ngClass]="{ 'fill-word-ceil--active': active }">
      <span class="fill-word-ceil__text">{{ letter }}</span>
    </div>
  `,
  styleUrls: ['fill-word-ceil.component.scss']
})
export class FillWordCeilComponent {
  @Input() letter!: string;
  @Input() active!: boolean;
}
