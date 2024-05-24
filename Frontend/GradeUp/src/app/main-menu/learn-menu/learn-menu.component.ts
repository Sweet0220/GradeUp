import {Component, OnInit} from '@angular/core';
import {SubjectService} from "../../../services/subject.service";
import {NgForOf, NgIf} from "@angular/common";
import {Subject} from "../../../entity/subject";

@Component({
  selector: 'app-learn-menu',
  standalone: true,
  imports: [
    NgIf,
    NgForOf
  ],
  templateUrl: './learn-menu.component.html',
  styleUrl: './learn-menu.component.css'
})
export class LearnMenuComponent implements OnInit {

  constructor(private subjectService: SubjectService) {
  }

  public currentImage: string = "assets/images/pictures/girl1.jpg";
  public currentName: string = "DEMO NAME"
  public description: string = "DEMO DESCRIPTION"
  public toggleRequests: boolean = false;
  public subjectList: Array<Subject> = new Array<Subject>();
  public uniList: Array<String> = new Array<String>();
  public yearList: Array<String> = new Array<String>();
  public subjectNameList: Array<String> = new Array<String>();
  public professorList: Array<String> = new Array<String>();

  ngOnInit(): void {
    this.subjectService.getAll().subscribe(response => {
      this.subjectList = response as Array<Subject>
      this.populateLists();
    })
  }

  private populateLists() : void {
    for (let subject of this.subjectList) {
      if (!this.uniList.includes(subject.university)) {
        this.uniList.push(subject.university)
      }
      if(!this.yearList.includes(subject.year.toString())) {
        this.yearList.push(subject.year.toString())
      }
      this.subjectNameList.push(subject.name)
      this.professorList.push(subject.professor)
    }
  }


}
