import { Routes } from '@angular/router';
import {LoginPageComponent} from "./login-page/login-page.component";
import {MainMenuComponent} from "./main-menu/main-menu.component";

export const routes: Routes = [
  {path: "login", component: LoginPageComponent},
  {path: "home", component: MainMenuComponent}
];
