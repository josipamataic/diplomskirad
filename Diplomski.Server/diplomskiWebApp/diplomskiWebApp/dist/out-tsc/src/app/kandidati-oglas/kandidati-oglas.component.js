import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { map, mergeMap } from 'rxjs/operators';
let KandidatiOglasComponent = class KandidatiOglasComponent {
    constructor(oglasService, route) {
        this.oglasService = oglasService;
        this.route = route;
        this.fetchData();
    }
    fetchData() {
        this.route.params.pipe(map(params => {
            const id = params['id'];
            return id;
        }), mergeMap(id => this.oglasService.getKandidatiByOglasPrijava(id))).subscribe(res => {
            this.kandidati = res;
        });
        // this.oglasService.getKandidatiByOglasPrijava
    }
    ngOnInit() {
    }
};
KandidatiOglasComponent = __decorate([
    Component({
        selector: 'app-kandidati-oglas',
        templateUrl: './kandidati-oglas.component.html',
        styleUrls: ['./kandidati-oglas.component.css']
    })
], KandidatiOglasComponent);
export { KandidatiOglasComponent };
//# sourceMappingURL=kandidati-oglas.component.js.map