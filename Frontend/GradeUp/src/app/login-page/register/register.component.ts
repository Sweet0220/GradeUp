import { Component } from '@angular/core';

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
  imageUrl: string | ArrayBuffer = this.imagePath;

  onFileSelected(event: any): void {
    const inputFile = event.target.files[0];
    const reader = new FileReader();

    reader.onload = () => {
      // @ts-ignore
      this.imageUrl = reader.result;
    };

    reader.readAsDataURL(inputFile);
  }

  onSubmit(): void {
    console.log('Form submitted');
    console.log('Username:', this.username);
    console.log('Password:', this.password);
    console.log('Remember Me:', this.rememberMe);
    console.log('Image Path:', this.imagePath);
  }
}
