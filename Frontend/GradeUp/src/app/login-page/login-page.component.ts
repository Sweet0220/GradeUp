import { Component } from '@angular/core';
import {LoginService} from "../../services/login.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login-page.component.html',
  imports: [],
  styleUrl: './login-page.component.css'
})
export class LoginComponent {

  constructor(private loginService: LoginService, private router: Router) {}

  email: string = '';
  password: string = '';
  rememberMe: boolean = false;
  imagePath: string = "assets/images/logo.svg";

  login(): void {
    const emailInput: HTMLInputElement = <HTMLInputElement> document.getElementById("email");
    const passwordInput: HTMLInputElement = <HTMLInputElement>document.getElementById("password")
    this.email = emailInput.value
    this.password = passwordInput.value
    this.loginService.login(this.email, this.password).subscribe(response => {
      localStorage.setItem("user", response)
      this.router.navigateByUrl("home")
    },
      error => {
      console.log(error.error);
      })
  }
}

export class LoginPageComponent {
}
