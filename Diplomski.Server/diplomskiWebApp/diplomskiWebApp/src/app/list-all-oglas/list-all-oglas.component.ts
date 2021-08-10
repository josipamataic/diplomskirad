import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Industrija, OglasList } from '../models/Oglas';
import { OglasService } from '../services/oglas.service';

@Component({
  selector: 'app-list-all-oglas',
  templateUrl: './list-all-oglas.component.html',
  styleUrls: ['./list-all-oglas.component.css']
})
export class ListAllOglasComponent implements OnInit {

  oglasi: Array<OglasList> 
  oglasiConst: Array<OglasList>
  industrije: Industrija[] = [];
  constructor(private oglasService: OglasService, private router: Router) { }

  ngOnInit() {
    this.fetchIndustrije()
    this.fetchOglasi()
  }

  fetchOglasi(){
    this.oglasService.getAllOglasi().subscribe(oglasi=>{
      this.oglasiConst = oglasi;
      this.oglasi = oglasi;
      console.log(this.oglasi)
    })
  }

  fetchIndustrije() {
    this.oglasService.getIndustrije().subscribe(industrija => {
      this.industrije = industrija;   
      console.log(this.industrije)      
    })
  }

  filterByIndustrija(indId) {
    if(indId == 616){
      this.oglasi = this.oglasiConst;
    }
    else{
      this.oglasi = this.oglasiConst.filter(p=>p.industrijaId == indId);
    }
      
  }

}
