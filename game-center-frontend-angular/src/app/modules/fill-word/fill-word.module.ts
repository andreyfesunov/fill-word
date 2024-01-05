import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FillWordRoutingModule} from "./fill-word-routing.module";
import {components} from "./components";
import {MatButtonModule} from "@angular/material/button";
import {MatSelectModule} from "@angular/material/select";
import {FillWordService} from "./services/fill-word.service";
import {FillWordApiService} from "./services/fill-word-api.service";
import {FillWordRootService} from "./services/fill-word-root.service";

const modules = [
  CommonModule,
  MatButtonModule,
  MatSelectModule
]

const services = [
  FillWordService,
  FillWordApiService,
  FillWordRootService
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
