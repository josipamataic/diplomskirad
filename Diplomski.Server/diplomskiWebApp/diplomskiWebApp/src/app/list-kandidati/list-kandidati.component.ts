import { Component, OnInit } from '@angular/core';
import { Industrija } from '../models/Oglas';
import { Kandidat } from '../models/Poslodavac';
import { KandidatService } from '../services/kandidat.service';

@Component({
  selector: 'app-list-kandidati',
  templateUrl: './list-kandidati.component.html',
  styleUrls: ['./list-kandidati.component.css']
})
export class ListKandidatiComponent implements OnInit {

  kandidati: Array<Kandidat>;
  industrija: Industrija;

  constructor(private kandidatService: KandidatService) { }

  ngOnInit() {
    this.fetchKandidati();
  }

  fetchKandidati(){
    this.kandidatService.getKandidati().subscribe(res=>{
      this.kandidati = res
    }   
      )
  }
}
