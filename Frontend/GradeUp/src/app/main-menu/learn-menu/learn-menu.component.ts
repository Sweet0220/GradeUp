import { Component } from '@angular/core';

@Component({
  selector: 'app-learn-menu',
  standalone: true,
  imports: [],
  templateUrl: './learn-menu.component.html',
  styleUrl: './learn-menu.component.css'
})
export class LearnMenuComponent {
  public currentImage: string = "assets/images/pictures/girls/girl1.jpg";
  public currentName: string = "DEMO NAME"
  public description: string = "DEMO DESCRIPTION"
}
