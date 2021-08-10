import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Poslodavac } from '../models/Poslodavac'
import { Industrija, Oglas } from '../models/Oglas';

@Injectable({
  providedIn: 'root'
})
export class PoslodavacService {

  private kandidatPath = environment.apiUrl + 'kandidatprofil'
  private poslodavacPath = environment.apiUrl + 'poslodavacprofil'

  constructor(private http: HttpClient) { }

  getMyProfile() : Observable<Poslodavac>{
    return this.http.get<Poslodavac>(this.poslodavacPath);
  }

  editPoslodavac(data){
    return this.http.put(this.poslodavacPath, data);
  }
  getPoslodavci() : Observable<Array<Poslodavac>>{
    return this.http.get<Array<Poslodavac>>(this.poslodavacPath +'/poslodavci')
  }
  getIndustrije(): Observable<Array<Industrija>> {
    return this.http.get<Array<Industrija>>(this.kandidatPath +  '/industrije')
  }
  
  getOglasiByPoslodavac(id): Observable<Array<Oglas>>{
    return this.http.get<Array<Oglas>>(this.poslodavacPath + '/' + id + '/oglasi')
  }
}
