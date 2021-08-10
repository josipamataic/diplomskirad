import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Industrija } from '../models/Oglas';
import { Poslodavac } from '../models/Poslodavac';
import { PoslodavacService } from '../services/poslodavac.service';

@Component({
  selector: 'app-edit-poslodavac',
  templateUrl: './edit-poslodavac.component.html',
  styleUrls: ['./edit-poslodavac.component.css']
})
export class EditPoslodavacComponent implements OnInit {

  poslodavacForm: FormGroup;
  poslodavac: Poslodavac;
  industrije: Industrija[] = [];

  constructor(private fb: FormBuilder,
    private router: Router,
    private poslodavacService: PoslodavacService,
    private toastrService: ToastrService) {
      this.poslodavacForm = this.fb.group({       
      //  'userName' : [''],
       // 'email':  [''],
        'nazivFirme' : [''],
        'kontakt' : [''],
        'email': [''],
        'industrijaId':  [''],
        'opis':  [''],
        'zemlja':  [''],
        'privatniProfil': ['']
      })
    }

  ngOnInit() {
    this.fetchIndustrije();
    this.poslodavacService.getMyProfile().subscribe(podaci => {
      this.poslodavac = podaci;
      console.log(podaci);
      this.poslodavacForm = this.fb.group({
       // 'userName' : [this.poslodavac.userName],
      
        'nazivFirme' : [this.poslodavac.nazivFirme],
        'kontakt' : [this.poslodavac.kontakt],
        'email':  [this.poslodavac.email],
        'industrijaId': [this.poslodavac.industrijaId],
        'opis':  [this.poslodavac.opis],
        'zemlja':  [this.poslodavac.zemlja],
        'privatniProfil': [this.poslodavac.privatniProfil]
      })        
    })   
  }

  editPoslodavac(){
    
    this.poslodavacService.editPoslodavac({
        'nazivFirme' : this.poslodavacForm.get('nazivFirme').value,
        'kontakt' : this.poslodavacForm.get('kontakt').value,
        'email': this.poslodavacForm.get('email').value,
        'industrijaId':  Number(this.poslodavacForm.get('industrijaId').value),
        'opis':  this.poslodavacForm.get('opis').value,
        'zemlja':  this.poslodavacForm.get('zemlja').value,
        'privatniProfil': this.poslodavacForm.get('privatniProfil').value === "true"? true: false
    }).subscribe(res=> {
      this.toastrService.success("Podaci profila su ažurirani.")
      this.router.navigate(["poslodavac/myprofile"])
      console.log(this.poslodavacForm.value);
    })
  }

  fetchIndustrije() {
    this.poslodavacService.getIndustrije().subscribe(industrija => {
      this.industrije = industrija;   
      console.log(this.industrije)      
    })
  }

}
