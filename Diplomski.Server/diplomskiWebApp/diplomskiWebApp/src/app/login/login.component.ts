import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  obavijesti: number;
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private toastrService: ToastrService) { 
    this.loginForm = this.fb.group({
      'userName': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    })
    console.log(this.loginForm)
  }

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.loginForm.value).subscribe(data => {
      this.authService.saveToken(data['token']);
      this.authService.saveRole(data['role']);
      if (this.authService.isUserKandidat()) {  
        this.authService.brojObavijesti().subscribe(broj => {
          this.obavijesti = broj
          console.log("Novih obavijesti:"+ broj)
          if(broj > 0){
            this.toastrService.info("Imate "+ broj+" novih obavijesti.")
          }
         
        })
        this.router.navigate(["allOglas"])      
      }
      else {
        this.router.navigate(["oglaslist"])
      }
      
    })  
  }

  get userName() {
    return this.loginForm.get('userName')
  }

  get password() {
    return this.loginForm.get('password')
  }

}
