import { Component } from '@angular/core';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css'
})
export class ForgotPasswordComponent {
  username: string = '';
  password: string = '';
  rememberMe: boolean = false;
  imagePath: string = "assets/images/lock.png";

  onSubmit(): void {
    console.log('Form submitted');
    console.log('Username:', this.username);
    console.log('Password:', this.password);
    console.log('Remember Me:', this.rememberMe)
  }
}
