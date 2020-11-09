import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService{

  constructor(private http : HttpClient) { }

  _url: string = "https://localhost:44304/api/user";

  getUser(user: User){ return this.http.post<Observable<User>>(this._url, user);}

}
