import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm : FormGroup;
  kandidat: boolean = true;
  pravila: boolean = false;

  constructor(private fb: FormBuilder, private authService : AuthService, private router: Router) {
    this.registerForm = this.fb.group({
      'userName': ['', Validators.required],
      'email' : ['', Validators.required],
      'password': ['', Validators.required],
      'uloga':['', Validators.required]
    })
   }

  ngOnInit(): void {
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      console.log(data)
      this.router.navigate(["login"])
    })

  }

  get userName() {
    return this.registerForm.get('userName')
  }

  get email() {
    return this.registerForm.get('email')
  }

  get password() {
    return this.registerForm.get('password')
  }

  get uloga(){
    return this.registerForm.get('uloga')
  }

  promijeniKandidat(){
    this.kandidat = true;
  }
  promijeniPoslodavac(){
    this.kandidat = false;
  }

  odobreno(){
    this.pravila = !this.pravila;
  }

}
