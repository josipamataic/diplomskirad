import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
let LoginComponent = class LoginComponent {
    constructor(fb, authService, router, toastrService) {
        this.fb = fb;
        this.authService = authService;
        this.router = router;
        this.toastrService = toastrService;
        this.loginForm = this.fb.group({
            'userName': ['', [Validators.required]],
            'password': ['', [Validators.required]]
        });
        console.log(this.loginForm);
    }
    ngOnInit() {
    }
    login() {
        this.authService.login(this.loginForm.value).subscribe(data => {
            this.authService.saveToken(data['token']);
            this.authService.saveRole(data['role']);
            if (this.authService.isUserKandidat()) {
                this.authService.brojObavijesti().subscribe(broj => {
                    this.obavijesti = broj;
                    console.log("Novih obavijesti:" + broj);
                    if (broj > 0) {
                        this.toastrService.info("Imate " + broj + " novih obavijesti.");
                    }
                });
                this.router.navigate(["allOglas"]);
            }
            else {
                this.router.navigate(["oglaslist"]);
            }
        });
    }
    get userName() {
        return this.loginForm.get('userName');
    }
    get password() {
        return this.loginForm.get('password');
    }
};
LoginComponent = __decorate([
    Component({
        selector: 'app-login',
        templateUrl: './login.component.html',
        styleUrls: ['./login.component.css']
    })
], LoginComponent);
export { LoginComponent };
//# sourceMappingURL=login.component.js.map