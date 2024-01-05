import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthRoutingModule} from "./auth-routing.module";
import {components} from "./components";
import {ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";

const modules = [
  CommonModule,
  ReactiveFormsModule,
  MatInputModule,
  MatButtonModule
]

@NgModule({
  declarations: [...components],
  imports: [...modules]
})
export class AuthModule {
}

@NgModule({
  imports: [AuthModule, AuthRoutingModule]
})
export class AuthModuleWithRouting {
}
