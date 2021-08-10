import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
let KandidatService = class KandidatService {
    constructor(http) {
        this.http = http;
        this.kandidatPath = environment.apiUrl + 'kandidatprofil';
    }
    getMyProfile() {
        return this.http.get(this.kandidatPath);
    }
    getKandidati() {
        return this.http.get(this.kandidatPath + '/kandidati');
    }
    editKandidat(data) {
        return this.http.put(this.kandidatPath, data);
    }
    getIndustrije() {
        return this.http.get(this.kandidatPath + '/industrije');
    }
    deleteKandidat() {
        return this.http.delete(this.kandidatPath);
    }
    deleteUser() {
        return this.http.delete(this.kandidatPath + '/deleteuser');
    }
};
KandidatService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], KandidatService);
export { KandidatService };
//# sourceMappingURL=kandidat.service.js.map