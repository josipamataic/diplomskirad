import { Component, OnInit } from '@angular/core';
import { Poslodavac } from '../models/Poslodavac';
import { PoslodavacService } from '../services/poslodavac.service';

@Component({
  selector: 'app-details-poslodavac',
  templateUrl: './details-poslodavac.component.html',
  styleUrls: ['./details-poslodavac.component.css']
})
export class DetailsPoslodavacComponent implements OnInit {

  poslodavac : Poslodavac

  constructor(private poslodavacService: PoslodavacService) { }
  
  ngOnInit() {
    this.fetchProfil()
  }

  fetchProfil(){
    this.poslodavacService.getMyProfile().subscribe(profil => {
      this.poslodavac = profil;
    })
  }


}
