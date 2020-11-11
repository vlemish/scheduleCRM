import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})
export class LoginService{

  constructor(private http : HttpClient) { }

  _url: string = "https://localhost:44394/api/authorization";

  logIn(user: User){ return this.http.post<Observable<any>>(this._url, user);}
  
  getToken(){
    return localStorage.getItem('token');
  }
  setToken(token: string){
    if(localStorage.getItem(token)===null){
      localStorage.setItem('token',token);
    }
  }
  removeToken(token: string){
    if(localStorage.getItem(token)!==null){
      localStorage.removeItem(token);
    }
  }
  getIdentity(){
    return localStorage.getItem('identity');
  }
  setIdentity(identity: string){
    if(localStorage.getItem(identity)===null){
      localStorage.setItem('identity',identity);
    }
  }
  removeIdentity(identity: string){
    if(localStorage.getItem(identity)!==null){
      localStorage.removeItem(identity);
    }
  }
  roleMatch(allowedRoles : string[]) :boolean {
    var isMatch = false;
    var userRole = this.getIdentity();
    allowedRoles.forEach(element => {
      if(userRole == element){
        isMatch=true;
        return false; 
      }
    });

    return isMatch;
  }
}
