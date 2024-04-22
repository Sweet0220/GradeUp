import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  public homeToggle: boolean = true;
  public learnToggle: boolean = false;
  public teachToggle: boolean = false;
  public messagesToggle: boolean = false;

  constructor() { }
}
