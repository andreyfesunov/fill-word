import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FillWordRoutingModule} from "./fill-word-routing.module";
import {components} from "./components";
import {services} from "./services";
import {MatButtonModule} from "@angular/material/button";
import {MatSelectModule} from "@angular/material/select";

const modules = [
  CommonModule,
  MatButtonModule,
  MatSelectModule
]

@NgModule({
  declarations: [...components],
  imports: [...modules],
  providers: [
    ...services
  ]
})
export class FillWordModule {
}

@NgModule({
  imports: [FillWordModule, FillWordRoutingModule]
})
export class FillWordModuleWithRouting {
}
