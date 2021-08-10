import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
let PoslodavacService = class PoslodavacService {
    constructor(http) {
        this.http = http;
        this.kandidatPath = environment.apiUrl + 'kandidatprofil';
        this.poslodavacPath = environment.apiUrl + 'poslodavacprofil';
    }
    getMyProfile() {
        return this.http.get(this.poslodavacPath);
    }
    editPoslodavac(data) {
        return this.http.put(this.poslodavacPath, data);
    }
    getPoslodavci() {
        return this.http.get(this.poslodavacPath + '/poslodavci');
    }
    getIndustrije() {
        return this.http.get(this.kandidatPath + '/industrije');
    }
    getOglasiByPoslodavac(id) {
        return this.http.get(this.poslodavacPath + '/' + id + '/oglasi');
    }
};
PoslodavacService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], PoslodavacService);
export { PoslodavacService };
//# sourceMappingURL=poslodavac.service.js.map