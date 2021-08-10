import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Roles } from '../models/Oglas';
let AuthService = class AuthService {
    constructor(http) {
        this.http = http;
        this.loginPath = environment.apiUrl + 'identity/login';
        this.registerPath = environment.apiUrl + 'identity/register';
        this.obavijestiPath = environment.apiUrl + 'oglas/noveobavijesti';
    }
    login(data) {
        return this.http.post(this.loginPath, data);
    }
    register(data) {
        return this.http.post(this.registerPath, data);
    }
    brojObavijesti() {
        return this.http.get(this.obavijestiPath);
    }
    saveToken(token) {
        localStorage.setItem('token', token);
    }
    getToken() {
        return localStorage.getItem('token');
    }
    deleteToken() {
        localStorage.removeItem('token');
    }
    saveRole(role) {
        localStorage.setItem('role', role);
    }
    getRole() {
        return localStorage.getItem('role');
    }
    isAuthenticated() {
        if (this.getToken()) {
            return true;
        }
        return false;
    }
    isUserKandidat() {
        if (this.getRole() === Roles.kandidat) {
            return true;
        }
        return false;
    }
    isUserPoslodavac() {
        if (this.getRole() === Roles.poslodavac) {
            return true;
        }
        return false;
    }
};
AuthService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], AuthService);
export { AuthService };
//# sourceMappingURL=auth.service.js.map