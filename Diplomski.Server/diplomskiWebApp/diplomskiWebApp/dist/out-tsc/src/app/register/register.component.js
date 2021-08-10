import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
let RegisterComponent = class RegisterComponent {
    constructor(fb, authService, router) {
        this.fb = fb;
        this.authService = authService;
        this.router = router;
        this.kandidat = true;
        this.pravila = false;
        this.registerForm = this.fb.group({
            'userName': ['', Validators.required],
            'email': ['', Validators.required],
            'password': ['', Validators.required],
            'uloga': ['', Validators.required]
        });
    }
    ngOnInit() {
    }
    register() {
        this.authService.register(this.registerForm.value).subscribe(data => {
            console.log(data);
            this.router.navigate(["login"]);
        });
    }
    get userName() {
        return this.registerForm.get('userName');
    }
    get email() {
        return this.registerForm.get('email');
    }
    get password() {
        return this.registerForm.get('password');
    }
    get uloga() {
        return this.registerForm.get('uloga');
    }
    promijeniKandidat() {
        this.kandidat = true;
    }
    promijeniPoslodavac() {
        this.kandidat = false;
    }
    odobreno() {
        this.pravila = !this.pravila;
    }
};
RegisterComponent = __decorate([
    Component({
        selector: 'app-register',
        templateUrl: './register.component.html',
        styleUrls: ['./register.component.css']
    })
], RegisterComponent);
export { RegisterComponent };
//# sourceMappingURL=register.component.js.map