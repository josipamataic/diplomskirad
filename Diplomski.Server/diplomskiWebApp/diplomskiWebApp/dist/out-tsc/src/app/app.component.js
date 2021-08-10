import { __decorate } from "tslib";
import { Component } from '@angular/core';
let AppComponent = class AppComponent {
    constructor(router, auth) {
        this.router = router;
        this.auth = auth;
        this.title = 'diplomskiWebApp';
    }
    get isAuthenticated() {
        return this.auth.isAuthenticated();
    }
    get isUserKandidat() {
        return this.auth.isUserKandidat();
    }
    get isUserPoslodavac() {
        return this.auth.isUserPoslodavac();
    }
    logOut() {
        this.auth.deleteToken();
        this.router.navigate(["login"]);
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css']
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map