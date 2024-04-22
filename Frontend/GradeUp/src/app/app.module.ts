import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {AppComponent} from "./app.component";
import {MainMenuComponent} from "./main-menu/main-menu.component";
import {LoginPageComponent} from "./login-page/login-page.component";
import {HomeMenuComponent} from "./main-menu/home-menu/home-menu.component";
import {LearnMenuComponent} from "./main-menu/learn-menu/learn-menu.component";
import {TeachMenuComponent} from "./main-menu/teach-menu/teach-menu.component";
import {MessagesMenuComponent} from "./main-menu/messages-menu/messages-menu.component";
@NgModule({
  imports: [BrowserModule, AppComponent, MainMenuComponent, LoginPageComponent, HomeMenuComponent, LearnMenuComponent, TeachMenuComponent, MessagesMenuComponent],
  declarations: [ ],
  exports:      [ AppComponent ]
})
export class AppModule { }
