import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Industrija, KandidatDetailsModel } from '../models/Oglas';
import { Kandidat } from '../models/Poslodavac';

@Injectable({
  providedIn: 'root'
})
export class KandidatService {

  private kandidatPath = environment.apiUrl + 'kandidatprofil'


  constructor(private http: HttpClient) { }

  getMyProfile(): Observable<Kandidat>{
    return this.http.get<Kandidat>(this.kandidatPath);
  }

  getKandidati(): Observable<Array<Kandidat>>{
    return this.http.get<Array<Kandidat>>(this.kandidatPath + '/kandidati');
  }

  editKandidat(data){
    return this.http.put(this.kandidatPath, data);
  }

  getIndustrije(): Observable<Array<Industrija>> {
    return this.http.get<Array<Industrija>>(this.kandidatPath +  '/industrije')
  }

  deleteKandidat(){
    return this.http.delete(this.kandidatPath);
  }

  deleteUser(){
    return this.http.delete(this.kandidatPath + '/deleteuser')
  }
}
