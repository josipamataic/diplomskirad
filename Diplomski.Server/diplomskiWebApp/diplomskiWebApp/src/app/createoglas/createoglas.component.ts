import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OglasService } from '../services/oglas.service';
import { ToastrService } from 'ngx-toastr';
import { Industrija } from '../models/Oglas';
import { Router } from '@angular/router';


@Component({
  selector: 'app-createoglas',
  templateUrl: './createoglas.component.html',
  styleUrls: ['./createoglas.component.css']
})
export class CreateoglasComponent {
  oglasForm:FormGroup;
  pitanjeForm:FormGroup;
  pitanje: string;
  industrije: Industrija[] = [];
  pitanja: string[] = [];

  constructor(private fb:FormBuilder, private oglasService: OglasService, private toastrService: ToastrService, private router: Router) { 
    this.oglasForm = this.fb.group({
      'naziv': ['', Validators.required],
      'industrijaId':['', Validators.required],
      'opis':['', Validators.required]
    })

    this.pitanjeForm = this.fb.group({
      'pitanje': ['']
    })
  } 

  ngOnInit() {
    this.fetchIndustrije();
   
  }

  get naziv(){
    return this.oglasForm.get('naziv');
  }

  get industrijaId(){
    return this.oglasForm.get('industrijaId');
  }

  get opis(){
    return this.oglasForm.get('opis');
  }

  create(){
    if(this.oglasForm.get('naziv').value && this.oglasForm.get('opis').value){
      console.log(this.oglasForm.value)
    this.oglasService
    .create({
      naziv: this.oglasForm.get('naziv').value,
      industrijaId: Number(this.oglasForm.get('industrijaId').value),
      opis: this.oglasForm.get('opis').value,
      pitanja: this.pitanja
    })
    .subscribe(res => {
      this.toastrService.success("Uspješno kreiran oglas")
      console.log(res);
      this.router.navigate(["oglaslist"])
    });
    }
    else{
      this.toastrService.error("Unesite sva potrebna polja")
    }
    
  }

  fetchIndustrije() {
    this.oglasService.getIndustrije().subscribe(industrija => {
      this.industrije = industrija;   
      console.log(this.industrije)      
    })
  }

  addQuestion() {
    if(this.pitanjeForm.value) {
      var pitanje = this.pitanjeForm.get('pitanje').value;
      this.pitanja.push(pitanje);
    }
  }

  removeQuestion(question) {
    this.pitanja = this.pitanja.filter(q => q !== question)
  }

}
