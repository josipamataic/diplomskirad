import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
let OglasService = class OglasService {
    constructor(http, authService) {
        this.http = http;
        this.authService = authService;
        this.deletepitanjePath = environment.apiUrl + 'oglas/deletepitanje';
        this.oglasPath = environment.apiUrl + 'oglas';
        this.prijavaPath = environment.apiUrl + 'prijava';
        this.industrijePath = environment.apiUrl + 'kandidatprofil';
    }
    create(data) {
        return this.http.post(this.oglasPath, data);
    }
    getOglasi() {
        return this.http.get(this.oglasPath);
    }
    getAllOglasi() {
        return this.http.get(this.oglasPath + '/all');
    }
    getMyKandidati(id) {
        return this.http.get(this.oglasPath + '/' + id + '/obavijest');
    }
    getOglas(id) {
        return this.http.get(this.oglasPath + '/' + id);
    }
    deleteOglas(id) {
        return this.http.delete(this.oglasPath + '/' + id);
    }
    arhivirajOglas(id) {
        return this.http.delete(this.oglasPath + '/' + id + '/arhiva');
    }
    editOglas(id, data) {
        return this.http.put(this.oglasPath + '/' + id, data);
    }
    getIndustrije() {
        return this.http.get(this.industrijePath + '/industrije');
    }
    createPrijava(data) {
        return this.http.post(this.prijavaPath, data);
    }
    getMyPrijave() {
        return this.http.get(this.prijavaPath);
    }
    deletePrijava(id) {
        return this.http.delete(this.prijavaPath + '/' + id);
    }
    //kandidati za slanje obavijesti
    getKandidatiByOglasPrijava(id) {
        return this.http.get(this.oglasPath + '/' + id + '/kandidati');
    }
    posaljiObavijest(data) {
        return this.http.post(this.oglasPath + '/posaljiobavijest', data);
    }
    getObavijesti() {
        return this.http.get(this.oglasPath + '/myobavijesti');
    }
    getPoslodavac(id) {
        return this.http.get(this.oglasPath + '/' + id + '/poslodavac');
    }
    checkPostojiLiPrijava(id) {
        return this.http.get(this.prijavaPath + '/myprijave/' + id);
    }
};
OglasService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], OglasService);
export { OglasService };
//# sourceMappingURL=oglas.service.js.map