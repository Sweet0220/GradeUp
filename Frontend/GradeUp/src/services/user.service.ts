import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "../entity/user";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public addUser(user: User): Observable<any> {
    const body = {
      "id": user.id,
      "username": user.username,
      "email": user.email,
      "password": user.password,
      "name": user.name,
      "sex": user.gender,
      "role": user.role
    }
    return this.http.post("http://localhost:5256/api/User", body, {responseType:"text"});
  }

}
