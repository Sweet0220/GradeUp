import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {AppComponent} from "./app.component";
import {MainMenuComponent} from "./main-menu/main-menu.component";
import {LoginPageComponent} from "./login-page/login-page.component";
@NgModule({
  imports: [BrowserModule, AppComponent, MainMenuComponent, LoginPageComponent],
  declarations: [ ],
  exports:      [ AppComponent ]
})
export class AppModule { }
