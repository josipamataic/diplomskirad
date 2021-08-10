import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CreateoglasComponent } from './createoglas/createoglas.component';
import { OglasService } from './services/oglas.service';
import { AuthGuardService } from './services/auth-guard.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { ListOglasComponent } from './list-oglas/list-oglas.component';
import { DetailsOglasComponent } from './details-oglas/details-oglas.component';
import { EditOglasComponent } from './edit-oglas/edit-oglas.component';
import { ErrorInterceptorService } from './services/error-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { EditPoslodavacComponent } from './edit-poslodavac/edit-poslodavac.component';
import { PoslodavacService } from './services/poslodavac.service';
import { DetailsPoslodavacComponent } from './details-poslodavac/details-poslodavac.component';
import { EditKandidatComponent } from './edit-kandidat/edit-kandidat.component';
import { KandidatService } from './services/kandidat.service';
import { DetailsKandidatComponent } from './details-kandidat/details-kandidat.component';
import { ListAllOglasComponent } from './list-all-oglas/list-all-oglas.component';
import { MyPrijaveListComponent } from './my-prijave-list/my-prijave-list.component';
import { KandidatiOglasComponent } from './kandidati-oglas/kandidati-oglas.component';
import { KandidatiPoslodavacComponent } from './kandidati-poslodavac/kandidati-poslodavac.component';
import { ObavijestListComponent } from './obavijest-list/obavijest-list.component';
import { ListPoslodavciComponent } from './list-poslodavci/list-poslodavci.component';
import { ListKandidatiComponent } from './list-kandidati/list-kandidati.component';
import { PolitikaPrivatnostiComponent } from './politika-privatnosti/politika-privatnosti.component';
import { UvjetiKoristenjaComponent } from './uvjeti-koristenja/uvjeti-koristenja.component';
import { PoslodavacOglasComponent } from './poslodavac-oglas/poslodavac-oglas.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CreateoglasComponent,
    ListOglasComponent,
    DetailsOglasComponent,
    EditOglasComponent,
    EditPoslodavacComponent,
    DetailsPoslodavacComponent,
    EditKandidatComponent,
    DetailsKandidatComponent,    
    ListAllOglasComponent, MyPrijaveListComponent, KandidatiOglasComponent, KandidatiPoslodavacComponent, ObavijestListComponent, ListPoslodavciComponent, ListKandidatiComponent, PolitikaPrivatnostiComponent, UvjetiKoristenjaComponent, PoslodavacOglasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule, 
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [AuthService, OglasService, AuthGuardService, PoslodavacService, KandidatService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptorService,
    multi: true
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptorService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
