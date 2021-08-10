import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Oglas } from '../models/Oglas';
import { OglasService } from '../services/oglas.service';

@Component({
  selector: 'app-list-oglas',
  templateUrl: './list-oglas.component.html',
  styleUrls: ['./list-oglas.component.css']
})
export class ListOglasComponent implements OnInit {

  oglas: Array<Oglas>
  constructor(private oglasService: OglasService, private router: Router, private toastrService: ToastrService) { }

  ngOnInit() {
    this.fetchOglasi()
  }

  fetchOglasi() {
    this.oglasService.getOglasi().subscribe(oglas => {
      this.oglas = oglas;
      console.log(this.oglas)
    })
  }

  deleteOglas(id){
   // var result = confirm("Želite li izbrisati oglas?");
   // if(result == true){
      console.log("hello")
      this.oglasService.deleteOglas(id).subscribe(res => {
        this.toastrService.success("Oglas uspješno obrisan.")
        this.fetchOglasi()
      })
   // }
   
  }

  arhivirajOglas(id){
    this.oglasService.arhivirajOglas(id).subscribe(res => {
      this.toastrService.success("Oglas arhiviran.")
      this.fetchOglasi()
    })
  }

  editOglas(id){
    this.router.navigate(["oglas/" + id + "/edit"])
  }


}
