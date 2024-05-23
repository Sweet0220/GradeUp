import {Component, OnInit} from '@angular/core';
import {User} from "../../../entity/user";

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
    const json: any = localStorage.getItem("user") ?? {};
    console.log(json)
    this.user = JSON.parse(json) as User
    console.log(this.user)
  }
}
