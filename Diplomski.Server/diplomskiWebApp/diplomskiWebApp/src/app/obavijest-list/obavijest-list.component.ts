import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ObavijestDetailsModel, Oglas } from '../models/Oglas';
import { OglasService } from '../services/oglas.service';

@Component({
  selector: 'app-obavijest-list',
  templateUrl: './obavijest-list.component.html',
  styleUrls: ['./obavijest-list.component.css']
})
export class ObavijestListComponent implements OnInit {

  obavijesti: Array<ObavijestDetailsModel> 

  constructor(private oglasService: OglasService, private router: Router) { }

  ngOnInit() {
    this.fetchObavijesti()
  }

  fetchObavijesti(){
    this.oglasService.getObavijesti().subscribe(res=> {
      this.obavijesti = res;
    })
  }
}
