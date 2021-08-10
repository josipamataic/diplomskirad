import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'diplomskiWebApp';
  
  get isAuthenticated() {
    return this.auth.isAuthenticated();
  }

  get isUserKandidat(){
    return this.auth.isUserKandidat();
  }

  get isUserPoslodavac(){
    return this.auth.isUserPoslodavac();
  }
  
  constructor (private router: Router, private auth: AuthService) {    
  }

  logOut() {
    this.auth.deleteToken();
    this.router.navigate(["login"])
  }
}
