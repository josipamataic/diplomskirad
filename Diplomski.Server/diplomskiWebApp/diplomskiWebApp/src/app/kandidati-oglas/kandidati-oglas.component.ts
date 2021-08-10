import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, mergeMap } from 'rxjs/operators';
import { KandidatDetailsModel, Oglas } from '../models/Oglas';
import { OglasService } from '../services/oglas.service';

@Component({
  selector: 'app-kandidati-oglas',
  templateUrl: './kandidati-oglas.component.html',
  styleUrls: ['./kandidati-oglas.component.css']
})
export class KandidatiOglasComponent implements OnInit {

  kandidati: Array<KandidatDetailsModel>

  constructor(private oglasService: OglasService, private route: ActivatedRoute) {
    this.fetchData()
   }

  

  fetchData(){
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id
    }), mergeMap(id => this.oglasService.getKandidatiByOglasPrijava(id))).subscribe(res => {
          this.kandidati = res
    })
   // this.oglasService.getKandidatiByOglasPrijava
  }

  ngOnInit(){

  }

}
