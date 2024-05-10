import {createComponent, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {AppComponent} from "./app.component";
import {MainMenuComponent} from "./main-menu/main-menu.component";
import {LoginComponent} from "./login-page/login-page.component";
import {RouterModule, Routes} from "@angular/router";


@NgModule({
  imports: [BrowserModule, AppComponent, MainMenuComponent, LoginComponent, RouterModule],
  declarations: [ ],
  exports:      [ AppComponent ]

})
export class AppModule { }
