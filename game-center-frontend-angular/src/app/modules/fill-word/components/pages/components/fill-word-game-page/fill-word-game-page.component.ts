import {ChangeDetectionStrategy, Component, HostBinding, ViewEncapsulation} from "@angular/core";
import {FillWordGamePageState} from "../../states/fill-word-game-page.state";

@Component({
  selector: "app-fill-word-game-page",
  templateUrl: "fill-word-game-page.component.html",
  styleUrls: ["fill-word-game-page.component.scss"],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [FillWordGamePageState]
})
export class FillWordGamePageComponent {
  @HostBinding('class.host-class') addHostClass = true;
  @HostBinding('class.fill-word-game-page') addPageClass = true;

  constructor(public readonly state: FillWordGamePageState) {
  }
}
