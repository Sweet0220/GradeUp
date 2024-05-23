import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) { }
  public login(email: string, password: string): Observable<any> {
    const body = {"email": email, "password": password};
    return this.http.post("http://localhost:5256/api/Authentication/login", body);
  }
}
