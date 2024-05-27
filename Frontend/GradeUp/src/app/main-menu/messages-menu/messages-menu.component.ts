import { Component } from '@angular/core';
import {CommonModule} from "@angular/common";
@Component({
  selector: 'app-messages-menu',
  standalone: true,
  templateUrl: './messages-menu.component.html',
  styleUrls: ['./messages-menu.component.css'],
  imports: [CommonModule]
})
export class MessagesMenuComponent {
  items: any[] = [
    {image:'/assets/images/pictures/girl1.jpg', name: 'Ionela', subject: 'Programarea Calculatoarelor' },
    {image:'../../../assets/images/pictures/girl3.jpg', name:  'Oana', subject: 'Bazele Circuitelor Electronice' },
    {image:'../../../assets/images/pictures/girl4.jpeg', name:  'Rebeca', subject: 'Electrotehnica' },
    {image:'../../../assets/images/pictures/girl5.jpg', name:  'Diana', subject: 'Matematici Speciale' },
    {image:'../../../assets/images/pictures/girl6.jpg', name:  'Roxana', subject: 'Teoria Sistemelor I' },
    {image:'../../../assets/images/pictures/girl7.jpg', name:  'Maria', subject: 'Proiectarea algoritmilor' },
    {image:'../../../assets/images/pictures/girl8.jpg', name:  'Marcela', subject: 'Teoria Sistemelor II' },
  ];
  itemsteach: any[]=[
    {image:'/assets/images/pictures/girl_teach1.jpg', name: 'Antonia', subject: 'Programarea Calculatoarelor' },
    {image:'../../../assets/images/pictures/girl_teach2.jpg', name:  'Raluca', subject: 'Bazele Circuitelor Electronice' },
    {image:'../../../assets/images/pictures/girl_teach3.jpg', name:  'Alexandra', subject: 'Electrotehnica' },
    {image:'../../../assets/images/pictures/girl_teach4.jpg', name:  'Melisa', subject: 'Teoria Sistemelor I' },
    {image:'../../../assets/images/pictures/girl_teach5.jpg', name:  'Gabriela', subject: 'Proiectarea algoritmilor' },
    {image:'../../../assets/images/pictures/girl_teach6.jpg', name:  'Roberta', subject: 'Teoria Sistemelor II' },
    {image:'../../../assets/images/pictures/girl_teach7.jpg', name:  'Ecaterina', subject: 'Informatica Industriala' },
    {image:'../../../assets/images/pictures/girl_teach8.jpg', name:  'Ioana', subject: 'Identificarea Sistemelor' },
  ];
  acceptedItem: any[]=[

  ];
  acceptedSteach: any[]=[

  ];

  handleNo(item: any) {
    const index = this.items.indexOf(item);
    if (index !== -1) {
      this.items.splice(index, 1);
    }
  }
  handleYes(item: any) {
    const index = this.items.indexOf(item);
    if (index !== -1) {
      this.items.splice(index, 1);
      this.acceptedItem.push(item);
    }
  }
  handleNoTeach(item: any) {
    const index = this.itemsteach.indexOf(item);
    if (index !== -1) {
      this.itemsteach.splice(index, 1);
    }
  }
  handleYesTeach(item: any) {
    const index = this.itemsteach.indexOf(item);
    if (index !== -1) {
      this.itemsteach.splice(index, 1);
      this.acceptedSteach.push(item);
    }
  }
}
