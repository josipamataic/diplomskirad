import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Industrija } from '../models/Oglas';
import { Poslodavac } from '../models/Poslodavac';
import { PoslodavacService } from '../services/poslodavac.service';

@Component({
  selector: 'app-list-poslodavci',
  templateUrl: './list-poslodavci.component.html',
  styleUrls: ['./list-poslodavci.component.css']
})
export class ListPoslodavciComponent implements OnInit {

  poslodavci: Array<Poslodavac>
  industrija: Industrija;

  constructor(private poslodavacService: PoslodavacService, private router: Router) { }

  ngOnInit() {
    this.fetchPoslodavci()
  }

  fetchPoslodavci(){
    this.poslodavacService.getPoslodavci().subscribe(res => {
      this.poslodavci = res;
    })
  }

}
