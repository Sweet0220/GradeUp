import { Routes } from '@angular/router';
import {LoginComponent, LoginPageComponent} from "./login-page/login-page.component";
import {MainMenuComponent} from "./main-menu/main-menu.component";
import {RegisterComponent} from "./login-page/register/register.component";
import {ForgotPasswordComponent} from "./login-page/forgot-password/forgot-password.component";

export const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "home", component: MainMenuComponent},
  {path: "register", component: RegisterComponent},
  {path: "forgot", component: ForgotPasswordComponent},
  {path: "", redirectTo: "login", pathMatch: "full"}
];
