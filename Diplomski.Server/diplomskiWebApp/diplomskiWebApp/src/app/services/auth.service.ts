import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginComponent } from '../login/login.component';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Roles } from '../models/Oglas';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiUrl + 'identity/login'
  private registerPath = environment.apiUrl + 'identity/register'
  private obavijestiPath = environment.apiUrl + 'oglas/noveobavijesti'
  constructor(private http: HttpClient) {
    
   }

   login(data) : Observable<any> {
    return this.http.post(this.loginPath, data)
  }

  register(data) : Observable<any> {
    return this.http.post(this.registerPath, data)
  }  

  brojObavijesti(): Observable<number> {
    return this.http.get<number>(this.obavijestiPath)
  }

  saveToken(token) {
    localStorage.setItem('token', token)
  }

  getToken() {
    return localStorage.getItem('token')
  }
  
  deleteToken() {
    localStorage.removeItem('token');
  }

  saveRole(role) {
    localStorage.setItem('role', role)
  }

  getRole() {
    return localStorage.getItem('role')
  }

  isAuthenticated() {
    if(this.getToken()){
      return true
    }
    return false;
  }

  isUserKandidat() {
    if(this.getRole() === Roles.kandidat){
      return true
    }
    return false;
  }

  isUserPoslodavac() {
    if(this.getRole() === Roles.poslodavac){
      return true
    }
    return false;
  }
 
 
}
