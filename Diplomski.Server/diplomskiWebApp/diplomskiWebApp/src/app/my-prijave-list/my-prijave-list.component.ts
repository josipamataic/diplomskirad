import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MyPrijave } from '../models/Oglas';
import { OglasService } from '../services/oglas.service';

@Component({
  selector: 'app-my-prijave-list',
  templateUrl: './my-prijave-list.component.html',
  styleUrls: ['./my-prijave-list.component.css']
})
export class MyPrijaveListComponent implements OnInit {

  prijave: Array<MyPrijave> 
  constructor(private oglasService: OglasService, private router: Router, private toastrService: ToastrService) { }

  ngOnInit(){
    this.fetchPrijave()
  }

  fetchPrijave(){
    this.oglasService.getMyPrijave().subscribe(prijave =>{
      this.prijave = prijave
    })
  }

  deletePrijava(id){
    this.oglasService.deletePrijava(id).subscribe(res =>{
      this.toastrService.success("Prijava uspješno obrisana.")
      this.fetchPrijave()
    })
  }

}
