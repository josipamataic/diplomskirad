import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Oglas, Industrija, PitanjeOdgovor, OglasList, MyPrijave, KandidatDetailsModel, CreateObavijestModel, ObavijestDetailsModel } from '../models/Oglas';
import { AuthService } from './auth.service';
import { Poslodavac } from '../models/Poslodavac';

@Injectable({
  providedIn: 'root'
})
export class OglasService {
  private deletepitanjePath = environment.apiUrl + 'oglas/deletepitanje';
  private oglasPath = environment.apiUrl + 'oglas';
  private prijavaPath = environment.apiUrl + 'prijava';
  private industrijePath = environment.apiUrl + 'kandidatprofil';
  constructor(private http: HttpClient, private authService: AuthService) { }

  create(data): Observable<Oglas>{
   
    return this.http.post<Oglas>(this.oglasPath, data)
  }

  getOglasi(): Observable<Array<Oglas>> {
    return this.http.get<Array<Oglas>>(this.oglasPath)
  }

  getAllOglasi(): Observable<Array<OglasList>>{
    return this.http.get<Array<OglasList>>(this.oglasPath + '/all')
  }

  getMyKandidati(id): Observable<Array<KandidatDetailsModel>>{
    return this.http.get<Array<KandidatDetailsModel>>(this.oglasPath + '/' + id + '/obavijest')
  }
  
  getOglas(id): Observable<Oglas> {
    return this.http.get<Oglas>(this.oglasPath + '/' + id)
  }

  deleteOglas(id) {
    return this.http.delete(this.oglasPath + '/' + id)
  }

  arhivirajOglas(id){
    return this.http.delete(this.oglasPath + '/' + id + '/arhiva')
  }

  editOglas(id, data){
    return this.http.put(this.oglasPath + '/' + id, data)
  }

  getIndustrije(): Observable<Array<Industrija>> {
    return this.http.get<Array<Industrija>>(this.industrijePath +  '/industrije')
  }

  createPrijava(data): Observable<PitanjeOdgovor>{
    return this.http.post<PitanjeOdgovor>(this.prijavaPath, data)
  }

  getMyPrijave(): Observable<Array<MyPrijave>>{
    return this.http.get<Array<MyPrijave>>(this.prijavaPath);
  }

  deletePrijava(id){
    return this.http.delete(this.prijavaPath + '/' + id)
  }

  //kandidati za slanje obavijesti
  getKandidatiByOglasPrijava(id): Observable<Array<KandidatDetailsModel>>{
    return this.http.get<Array<KandidatDetailsModel>>(this.oglasPath +'/'+ id + '/kandidati')
  }

  posaljiObavijest(data): Observable<CreateObavijestModel>{
    return this.http.post<CreateObavijestModel>(this.oglasPath + '/posaljiobavijest', data)
  }

  getObavijesti(): Observable<Array<ObavijestDetailsModel>>{
    return this.http.get<Array<ObavijestDetailsModel>>(this.oglasPath + '/myobavijesti')
  }

  getPoslodavac(id): Observable<Poslodavac>{
    return this.http.get<Poslodavac>(this.oglasPath + '/' + id + '/poslodavac')
  }

  checkPostojiLiPrijava(id):Observable<boolean>{
    return this.http.get<boolean>(this.prijavaPath + '/myprijave/' + id)
  }


}
