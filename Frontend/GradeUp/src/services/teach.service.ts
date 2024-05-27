import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Teaching} from "../entity/teaching";

@Injectable({
  providedIn: 'root'
})
export class TeachService {

  constructor(private http: HttpClient) { }
  public addTeach(teach: Teaching): Observable<any> {
    const body = {
      "id": teach.id,
      "id_user": teach.id,
      "id_subject": teach.id,
    }
    return this.http.post("http://localhost:5256/api/Teaching", body, {responseType:"text"});
  }

}
