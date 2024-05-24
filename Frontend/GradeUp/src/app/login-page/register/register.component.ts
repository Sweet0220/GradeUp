import { Component } from '@angular/core';
import {UserService} from "../../../services/user.service";
import {User} from "../../../entity/user";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  username: string = '';
  password: string = '';
  rememberMe: boolean = false;
  imagePath: string = "assets/images/logo.svg";
  imageUrl: string | ArrayBuffer | null = this.imagePath;
  inputFile: File[] = [];

  constructor(private userService: UserService, private router: Router) {
  }

  onFileSelected(event: any): void {
    this.inputFile = event.target.files[0];
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = () => {
      this.imageUrl = reader.result;
    };

    reader.readAsDataURL(file);
    console.log(this.imageUrl)
  }

  onSubmit(): void {
    console.log('Form submitted');
    console.log('Username:', this.username);
    console.log('Password:', this.password);
    console.log('Remember Me:', this.rememberMe);
    console.log('Image Path:', this.imagePath);
  }

  public registerUser() {
    let usernameInput: HTMLInputElement = <HTMLInputElement> document.getElementById("username");
    let username: string = usernameInput.value;

    let emailInput: HTMLInputElement = <HTMLInputElement> document.getElementById("email");
    let email: string = emailInput.value;

    let passwordInput: HTMLInputElement = <HTMLInputElement> document.getElementById("password");
    let password: string = passwordInput.value;

    let nameInput: HTMLInputElement = <HTMLInputElement> document.getElementById("name");
    let name: string = nameInput.value;

    let genderSelect: HTMLSelectElement = <HTMLSelectElement> document.getElementById("gender-select");
    let gender: string = genderSelect.value;
    let role: string = "user";

    if (username != "" && email != "" && password != "" && name != "" && gender != "" && this.inputFile.length != 0) {
      let user: User = new User();
      user.id = 0;
      user.username = username;
      user.email = email;
      user.password = password;
      user.name = name;
      user.gender = gender;
      user.role = role;
      this.userService.addUser(user).subscribe(response => {
        console.log(response);
        this.router.navigateByUrl("/login");
      });
    }



  }
}
