import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from "./core/guards/auth.guard";

export enum AppRoutes {
  FillWord = "fill-word",
  Auth = 'auth'
}

const routes: Routes = [
  {
    canActivate: [AuthGuard],
    path: AppRoutes.FillWord,
    loadChildren: () => import('./modules/fill-word/fill-word.module').then(m => m.FillWordModuleWithRouting)
  },
  {
    path: AppRoutes.Auth,
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModuleWithRouting)
  },
  {
    path: "**",
    pathMatch: "full",
    redirectTo: AppRoutes.Auth
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
