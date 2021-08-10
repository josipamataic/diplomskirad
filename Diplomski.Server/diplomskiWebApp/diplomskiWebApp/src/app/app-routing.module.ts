import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateoglasComponent } from './createoglas/createoglas.component';
import { DetailsKandidatComponent } from './details-kandidat/details-kandidat.component';
import { DetailsOglasComponent } from './details-oglas/details-oglas.component';
import { DetailsPoslodavacComponent } from './details-poslodavac/details-poslodavac.component';
import { EditKandidatComponent } from './edit-kandidat/edit-kandidat.component';
import { EditOglasComponent } from './edit-oglas/edit-oglas.component';
import { EditPoslodavacComponent } from './edit-poslodavac/edit-poslodavac.component';
import { KandidatiOglasComponent } from './kandidati-oglas/kandidati-oglas.component';
import { KandidatiPoslodavacComponent } from './kandidati-poslodavac/kandidati-poslodavac.component';
import { ListAllOglasComponent } from './list-all-oglas/list-all-oglas.component';
import { ListKandidatiComponent } from './list-kandidati/list-kandidati.component';
import { ListOglasComponent } from './list-oglas/list-oglas.component';
import { ListPoslodavciComponent } from './list-poslodavci/list-poslodavci.component';
import { LoginComponent } from './login/login.component';
import { MyPrijaveListComponent } from './my-prijave-list/my-prijave-list.component';
import { ObavijestListComponent } from './obavijest-list/obavijest-list.component';
import { PolitikaPrivatnostiComponent } from './politika-privatnosti/politika-privatnosti.component';
import { PoslodavacOglasComponent } from './poslodavac-oglas/poslodavac-oglas.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { UvjetiKoristenjaComponent } from './uvjeti-koristenja/uvjeti-koristenja.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent},
  { path:'createoglas', component:CreateoglasComponent, canActivate: [AuthGuardService] },
  { path: 'oglaslist', component: ListOglasComponent, canActivate: [AuthGuardService] },
  { path: 'oglas/:id', component: DetailsOglasComponent, canActivate: [AuthGuardService] },
  { path: 'oglas/:id/edit', component: EditOglasComponent },
  { path: 'poslodavac/edit', component: EditPoslodavacComponent, canActivate: [AuthGuardService]},
  { path: 'poslodavac/myprofile', component:DetailsPoslodavacComponent },
  { path: 'kandidat/edit', component:EditKandidatComponent, canActivate: [AuthGuardService]},
  { path: 'kandidat/myprofile', component:DetailsKandidatComponent, canActivate: [AuthGuardService]},
  { path: 'allOglas', component:ListAllOglasComponent},
  { path: 'prijava/myprijave', component : MyPrijaveListComponent, canActivate: [AuthGuardService]},
  { path: 'oglas/:id/kandidati', component: KandidatiOglasComponent, canActivate: [AuthGuardService]},
  { path: 'oglas/:id/obavijest', component: KandidatiPoslodavacComponent, canActivate: [AuthGuardService]},
  { path: 'obavijesti', component: ObavijestListComponent, canActivate:[AuthGuardService]},
  { path: 'poslodavci', component: ListPoslodavciComponent},
  { path: 'kandidati', component: ListKandidatiComponent, canActivate: [AuthGuardService]},
  { path: 'poslodavac/:id/oglasi', component:PoslodavacOglasComponent },
  { path: 'politikaprivatnosti', component: PolitikaPrivatnostiComponent},
  { path: 'uvjetikoristenja', component: UvjetiKoristenjaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
