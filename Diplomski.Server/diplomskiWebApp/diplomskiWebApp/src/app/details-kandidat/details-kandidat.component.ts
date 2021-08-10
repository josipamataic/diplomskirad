import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Industrija } from '../models/Oglas';
import { Kandidat } from '../models/Poslodavac';
import { AuthService } from '../services/auth.service';
import { KandidatService } from '../services/kandidat.service';

@Component({
  selector: 'app-details-kandidat',
  templateUrl: './details-kandidat.component.html',
  styleUrls: ['./details-kandidat.component.css']
})
export class DetailsKandidatComponent implements OnInit {

  kandidat : Kandidat
  industrija: Industrija

  constructor(private kandidatService: KandidatService, private router:Router, private toastrService: ToastrService,
     private auth: AuthService) { }

  ngOnInit() {
    this.fetchProfil()
  }

  fetchProfil(){
    this.kandidatService.getMyProfile().subscribe(profil => {
      this.kandidat = profil;
      console.log(profil);
    })
  }

  deleteKandidat(){
    this.kandidatService.deleteKandidat().subscribe(res=>{
      this.toastrService.success("Osobni podaci obrisani")
      this.fetchProfil()
    })
  }

  deleteUser(){
    this.kandidatService.deleteUser().subscribe(res => {
      this.auth.deleteToken();
      this.toastrService.error("Profil obrisan")
      this.router.navigate(["register"])
    })
  }

}
