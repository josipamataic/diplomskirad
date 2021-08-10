import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Oglas, PitanjeOdgovor } from '../models/Oglas';
import { OglasService } from '../services/oglas.service';
import { map, mergeMap } from 'rxjs/operators';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-details-oglas',
  templateUrl: './details-oglas.component.html',
  styleUrls: ['./details-oglas.component.css']
})
export class DetailsOglasComponent implements OnInit {
  createOdgovoriForm: FormGroup;
  id: string;
  oglas: Oglas;
  prijavaMode: boolean = false;
  postojiPrijava: boolean = false;
 // pitanjeId: number;
  //odgovorTekst: string;
  //odgovori: PitanjeOdgovor[] = [];

  constructor(private fb:FormBuilder, private route: ActivatedRoute, private oglasService: OglasService,
     private toastrService: ToastrService, private auth: AuthService,
     private router: Router) { 
   // this.route.params.subscribe(res => {
   //   this.id = res['id'];
   //   this.oglasService.getOglas(this.id).subscribe( res => {
   //     this.oglas = res;
   //   })
   // })
   if(this.isUserKandidat){
    this.checkPostojiLiPrijava();
   }
   
   this.fetchData()
  
  
   }

  fetchData(){
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id
    }),mergeMap(id => this.oglasService.getOglas(id))).subscribe(res => {
      this.oglas = res;
      this.createOdgovoriForm = this.fb.group({
        // odgovori : this.fb.array([
          //this.fb.group({
          //  pitanjeId: [''],
           // odgovorTekst: ['']
           
          // })
      //   ])
        odgovori: this.fb.array([])
       })
    
       this.initFormArray()
    })
  }

  ngOnInit() {
    console.log("Hello")
  }
  
  onPrijaviSe(){
    console.log(this.oglas.pitanja)
    this.prijavaMode = true;
  }

  createPrijava(){

    if(this.usporedipitanjeodgovor()){
      console.log(this.createOdgovoriForm)
      console.log(this.createOdgovoriForm.value)
      this.oglasService.createPrijava({
        oglasId: this.oglas.id,
        odgovori: this.odgovor.value
      })
    .subscribe(res => {
      this.toastrService.success("Uspješno kreirana prijava")   
      this.router.navigate(["prijava/myprijave"])
      console.log(res);
    });
    }
    else{
      this.toastrService.warning("Unesite odgovore na sva pitanja.")
    }
    
    
  }

  usporedipitanjeodgovor(): boolean{
    var odgovori: Array<PitanjeOdgovor> = this.odgovor.value;
    return this.oglas.pitanja.length==odgovori.filter(o=>o.odgovorTekst != '').length
  }

  get odgovor() {
    return this.createOdgovoriForm.get("odgovori") as FormArray;
  }

  get isUserKandidat(){
    return this.auth.isUserKandidat();
  }

  get isUserPoslodavac(){
    return this.auth.isUserPoslodavac();
  }

  initFormArray(){  
    console.log(this.oglas.pitanja)
    this.oglas.pitanja.forEach(element => {
      this.odgovor.push(this.fb.group({ pitanjeId: [element.id], odgovorTekst: [''] }))   
    })   
  }

  checkPostojiLiPrijava(){
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id
    }),mergeMap(id => this.oglasService.checkPostojiLiPrijava(id))).subscribe(res => {
     
      this.postojiPrijava = res;
       });   

    
    
  }
  

}
