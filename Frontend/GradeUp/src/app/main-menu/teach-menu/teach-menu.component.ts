import {Component, OnInit} from '@angular/core';
import {NgForOf} from "@angular/common";
import {SubjectService} from "../../../services/subject.service";
import {Subject} from "../../../entity/subject";
import {TeachService} from "../../../services/teach.service";
import {Teaching} from "../../../entity/teaching";

@Component({
  selector: 'app-teach-menu',
  standalone: true,
    imports: [
        NgForOf
    ],
  templateUrl: './teach-menu.component.html',
  styleUrl: './teach-menu.component.css'
})
export class TeachMenuComponent implements OnInit {
  constructor(private subjectService: SubjectService, private teachService: TeachService) {
  }

  public subjectList: Array<Subject> = new Array<Subject>();
  public uniList: Array<String> = new Array<String>();
  public subjectNameList: Array<String> = new Array<String>();
  public professorList: Array<String> = new Array<String>();

  ngOnInit(): void {
    this.subjectService.getAll().subscribe(response => {
      this.subjectList = response as Array<Subject>
      this.populateLists();
    })
  }

  private populateLists(): void {
    for (let subject of this.subjectList) {
      if (!this.uniList.includes(subject.university)) {
        this.uniList.push(subject.university)
      }
      this.subjectNameList.push(subject.name)
      this.professorList.push(subject.professor)
    }
  }

  public addTeach(): void {
    let facSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById("option-fac");
    let fac: string = facSelect.value;

    let yearSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById("option-an");
    let year: string = yearSelect.value;

    let subjectSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById("option-materie");
    let subject: string = subjectSelect.value;

    let profSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById("option-prof");
    let professor: string = profSelect.value;

    if (fac != "" && year!="" && subject!="" && professor!="") {
     let teach: Teaching = new Teaching();
     teach.userId = 0;
     teach.id = 0;
     teach.subjectId = 0
      this.teachService.addTeach(teach).subscribe(response => {console.log(response);
        console.log('Teaching was added to db');
        alert('Teaching was added to db');
      })
    }
  }
}


