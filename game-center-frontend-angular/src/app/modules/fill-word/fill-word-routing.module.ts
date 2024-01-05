import {NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {FillWordAllPageComponent} from "./components/pages/components/fill-word-all-page/fill-word-all-page.component";
import {
  FillWordGamePageComponent
} from "./components/pages/components/fill-word-game-page/fill-word-game-page.component";

export enum FillWordRoutes {
  All = "all"
}

const routes: Routes = [
  {
    path: FillWordRoutes.All,
    pathMatch: "full",
    component: FillWordAllPageComponent,
  },
  {
    path: ":id",
    pathMatch: "full",
    component: FillWordGamePageComponent
  },
  {
    path: "",
    pathMatch: "full",
    redirectTo: FillWordRoutes.All
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class FillWordRoutingModule {
}
