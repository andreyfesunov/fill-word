import {ChangeDetectionStrategy, Component, HostBinding, ViewEncapsulation} from "@angular/core";
import {LogInPageState} from "../../states/log-in-page.state";

@Component({
  selector: 'app-log-in-page-component',
  templateUrl: 'log-in-page.component.html',
  styleUrls: ['log-in-page.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [LogInPageState],
})
export class LogInPageComponent {
  @HostBinding('class.log-in-page') addPageClass = true;

  constructor(public readonly state: LogInPageState) {
  }
}
