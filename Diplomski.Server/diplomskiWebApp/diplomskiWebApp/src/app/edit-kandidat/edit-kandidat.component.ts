import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateoglasComponent } from '../createoglas/createoglas.component';
import { KandidatService } from '../services/kandidat.service';
import { Industrija } from '../models/Oglas';
import { Kandidat } from '../models/Poslodavac';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-kandidat',
  templateUrl: './edit-kandidat.component.html',
  styleUrls: ['./edit-kandidat.component.css']
})
export class EditKandidatComponent implements OnInit {

  kandidatForm: FormGroup;
  createOglas: CreateoglasComponent;
  kandidat: Kandidat;
  privatniKandidat: boolean;
  priv: boolean;   
  industrije: Industrija[] = [];

  constructor(private fb: FormBuilder, private router: Router, private kandidatService: KandidatService,
    private toastrService: ToastrService) {
    this.kandidatForm = this.fb.group({
      'ime' : [''],
      'prezime' : [''],
      'email': [''],
      'brojMobitela': [''],
      'datumRodenja':  [''],
      'industrijaId':  [''],
      'obrazovanje':  [''],
      'zemlja':  [''],
      'privatniProfil': ['']
    })
   }

  ngOnInit() {
    this.fetchIndustrije();
    this.kandidatService.getMyProfile().subscribe(podaci => {
      console.log(podaci)
      this.kandidat = podaci;
      this.privatniKandidat = this.kandidat.privatniProfil; 
      this.priv = this.kandidat.privatniProfil;     
      var datePipe = new DatePipe('en-US');
      var datumRodenja = datePipe.transform(this.kandidat.datumRodenja, 'dd.MM.yyyy');
      this.kandidatForm = this.fb.group({
        'ime' : [this.kandidat.ime],
        'prezime' : [this.kandidat.prezime],
        'email': [this.kandidat.email],
        'brojMobitela': [this.kandidat.brojMobitela],
        'datumRodenja': [this.kandidat.datumRodenja],
        'industrijaId':  [this.kandidat.industrijaId],
        'obrazovanje':  [this.kandidat.obrazovanje],
        'zemlja':  [this.kandidat.zemlja],
        'privatniProfil': [this.kandidat.privatniProfil]
      })
    })
  }

  editKandidat(){
    console.log(this.kandidatForm)
    this.kandidatService.editKandidat({
        'ime' : this.kandidatForm.get('ime').value,
        'prezime' : this.kandidatForm.get('prezime').value,
        'email': this.kandidatForm.get('email').value,
        'brojMobitela': this.kandidatForm.get('brojMobitela').value,
        'datumRodenja':  this.kandidatForm.get('datumRodenja').value,
        'industrijaId':  Number(this.kandidatForm.get('industrijaId').value),
        'obrazovanje':  this.kandidatForm.get('obrazovanje').value,
        'zemlja':  this.kandidatForm.get('zemlja').value,
        'privatniProfil': this.kandidatForm.get('privatniProfil').value === "true"? true: false
    }).subscribe(res=> {
      this.toastrService.success("Podaci profila su ažurirani.")
      this.router.navigate(["kandidat/myprofile"])})
  }  

  fetchIndustrije() {
    this.kandidatService.getIndustrije().subscribe(industrija => {
      this.industrije = industrija;   
      console.log(this.industrije)      
    })
  }

  privatni(){
    this.privatniKandidat = true;
  }

  javni(){
    this.privatniKandidat = false;
  }

 
}
