import {NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {LogInPageComponent} from "./components/pages/components/log-in-page/log-in-page.component";

const routes: Routes = [{
  path: "",
  pathMatch: "full",
  component: LogInPageComponent
}]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule {
}
