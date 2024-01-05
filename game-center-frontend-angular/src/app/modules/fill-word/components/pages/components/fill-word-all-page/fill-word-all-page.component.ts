import {ChangeDetectionStrategy, Component, HostBinding, ViewEncapsulation} from "@angular/core";
import {FillWordAllPageState} from "../../states/fill-word-all-page.state";

@Component({
  selector: "app-fill-word-all-page",
  templateUrl: "fill-word-all-page.component.html",
  styleUrls: ['fill-word-all-page.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [FillWordAllPageState]
})
export class FillWordAllPageComponent {
  @HostBinding('class.host-class') addHostClass = true;
  @HostBinding('class.fill-word-all-page') addPageClass = true;

  constructor(public readonly state: FillWordAllPageState) {
  }
}
