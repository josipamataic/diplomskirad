import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, mergeMap } from 'rxjs/operators';
import { KandidatDetailsModel, Oglas } from '../models/Oglas';
import { OglasService } from '../services/oglas.service';

@Component({
  selector: 'app-kandidati-poslodavac',
  templateUrl: './kandidati-poslodavac.component.html',
  styleUrls: ['./kandidati-poslodavac.component.css']
})
export class KandidatiPoslodavacComponent implements OnInit {

  // kandidati za OBAVIJEST  
  oglas: Oglas;
  id: number;
  kandidati: Array<KandidatDetailsModel>;
  obavijestForm: FormGroup;
  kandidatIds: string[] = [];

  constructor(private fb:FormBuilder, private oglasService: OglasService, private router: Router, private route:ActivatedRoute, 
    private toastrService: ToastrService) {
    this.obavijestForm = this.fb.group({
      'naslov': ['', Validators.required],
      'tekst': ['', Validators.required]
    })
   }

  ngOnInit() {
   // this.fetchKandidati()
   this.fetchOglas()
  }

  posaljiObavijest(){
    if(this.obavijestForm.get('naslov').value && this.obavijestForm.get('tekst').value){
      this.oglasService.posaljiObavijest({
        idOglas: this.id,      
        naslov: this.obavijestForm.get('naslov').value,
        tekst: this.obavijestForm.get('tekst').value,
        kandidatIds: this.kandidatIds
      }).subscribe(res => {
        this.toastrService.success("Obavijest poslana.")
        this.router.navigate(["oglaslist"])
      })
    }
    else{
      this.toastrService.error("Ispunite naslov i tekst.")
    }
    
  }

  fetchOglas(){
    this.route.params.pipe(map(params => {
      this.id = params['id'];       
    }), mergeMap(id => this.oglasService.getOglas(this.id))).subscribe(res => {
      this.oglas = res;
      this.fetchKandidati(this.id);
    })
  }

  fetchKandidati(id){
   this.oglasService.getMyKandidati(id).subscribe(res => {
      this.kandidati = res
      console.log(this.kandidati)
    })   
  }

  get naslov(){
    return this.obavijestForm.get('naslov');
  }

  get tekst(){
    return this.obavijestForm.get('tekst');
  }

  addKandidatId(kandidat){
    this.kandidatIds.push(kandidat.id);
    kandidat.oznacen = true;

  }

  removeKandidatId(kandidat){
    this.kandidatIds = this.kandidatIds.filter(q => q != kandidat.id)
    kandidat.oznacen = false;
  }

}
