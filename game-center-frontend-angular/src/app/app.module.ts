import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HttpClientModule} from "@angular/common/http";
import {CoreModule} from "./core/core.module";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

const declarations = [AppComponent];

const imports = [
  BrowserModule,
  AppRoutingModule,
  HttpClientModule,
  CoreModule,
  BrowserAnimationsModule
]

@NgModule({
  declarations: declarations,
  imports: imports,
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
