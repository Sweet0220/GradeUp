import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-home-menu',
  standalone: true,
  imports: [],
  templateUrl: './home-menu.component.html',
  styleUrl: './home-menu.component.css'
})
export class HomeMenuComponent implements OnInit {
  public user: any = "";
  ngOnInit() {
    this.user = localStorage.getItem("user");
  }
}
