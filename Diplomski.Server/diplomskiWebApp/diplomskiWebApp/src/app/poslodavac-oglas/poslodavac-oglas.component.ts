import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, mergeMap } from 'rxjs/operators';
import { Oglas } from '../models/Oglas';
import { Poslodavac } from '../models/Poslodavac';
import { OglasService } from '../services/oglas.service';
import { PoslodavacService } from '../services/poslodavac.service';

@Component({
  selector: 'app-poslodavac-oglas',
  templateUrl: './poslodavac-oglas.component.html',
  styleUrls: ['./poslodavac-oglas.component.css']
})
export class PoslodavacOglasComponent implements OnInit {

  oglasi: Array<Oglas>
  poslodavac: Poslodavac;
  poslodavacId: string;

  constructor(private poslodavacService: PoslodavacService, private route: ActivatedRoute, private oglasService: OglasService) { 
    this.fetchData()
  }

  

  fetchData(){
    this.route.params.pipe(map(params => {
      const id = params['id'];
      this.poslodavacId = id;
      return id
    }), mergeMap(id => this.poslodavacService.getOglasiByPoslodavac(id))).subscribe(res => {
      this.oglasi = res
      this.oglasService.getPoslodavac(this.poslodavacId).subscribe(poslodavac =>{
        this.poslodavac = poslodavac;
      })

    })
  }
  ngOnInit() {

  }



}
