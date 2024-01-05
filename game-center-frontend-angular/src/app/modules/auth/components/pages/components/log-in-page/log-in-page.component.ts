import {ChangeDetectionStrategy, Component, ViewEncapsulation} from "@angular/core";
import {LogInPageState} from "../../states/log-in-page.state";

@Component({
  selector: 'app-log-in-page-component',
  templateUrl: 'log-in-page.component.html',
  styleUrls: ['log-in-page.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [LogInPageState],
  host: {
    class: 'log-in-page'
  }
})
export class LogInPageComponent {
  constructor(public readonly state: LogInPageState) {
  }
}
