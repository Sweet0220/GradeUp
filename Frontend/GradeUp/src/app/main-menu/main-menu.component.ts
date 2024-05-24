import { Component } from '@angular/core';
import {MenuService} from "../../services/menu.service";
import {HomeMenuComponent} from "./home-menu/home-menu.component";
import {LearnMenuComponent} from "./learn-menu/learn-menu.component";
import {NgClass, NgIf} from "@angular/common";
import {TeachMenuComponent} from "./teach-menu/teach-menu.component";
import {MessagesMenuComponent} from "./messages-menu/messages-menu.component";
import {Router} from "@angular/router";

@Component({
  selector: 'app-main-menu',
  standalone: true,
  imports: [
    HomeMenuComponent,
    LearnMenuComponent,
    NgIf,
    TeachMenuComponent,
    MessagesMenuComponent,
    NgClass
  ],
  templateUrl: './main-menu.component.html',
  styleUrl: './main-menu.component.css'
})
export class MainMenuComponent {
  constructor(protected menuService: MenuService, private router: Router) {
  }

  toggleHomeMenu() {
    this.menuService.homeToggle = true;
    this.menuService.learnToggle = false;
    this.menuService.teachToggle = false;
    this.menuService.messagesToggle = false;
  }

  toggleLearnMenu() {
    this.menuService.homeToggle = false;
    this.menuService.learnToggle = true;
    this.menuService.teachToggle = false;
    this.menuService.messagesToggle = false;
  }

  toggleTeachMenu() {
    this.menuService.homeToggle = false;
    this.menuService.learnToggle = false;
    this.menuService.teachToggle = true;
    this.menuService.messagesToggle = false;
  }

  toggleMessagesMenu() {
    this.menuService.homeToggle = false;
    this.menuService.learnToggle = false;
    this.menuService.teachToggle = false;
    this.menuService.messagesToggle = true;
  }

  public logout() {
    localStorage.setItem("user", "");
    this.router.navigateByUrl("/login");
  }


}
