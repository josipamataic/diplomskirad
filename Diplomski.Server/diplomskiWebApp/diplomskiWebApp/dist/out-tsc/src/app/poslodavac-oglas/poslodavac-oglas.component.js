import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { map, mergeMap } from 'rxjs/operators';
let PoslodavacOglasComponent = class PoslodavacOglasComponent {
    constructor(poslodavacService, route, oglasService) {
        this.poslodavacService = poslodavacService;
        this.route = route;
        this.oglasService = oglasService;
        this.fetchData();
    }
    fetchData() {
        this.route.params.pipe(map(params => {
            const id = params['id'];
            this.poslodavacId = id;
            return id;
        }), mergeMap(id => this.poslodavacService.getOglasiByPoslodavac(id))).subscribe(res => {
            this.oglasi = res;
            this.oglasService.getPoslodavac(this.poslodavacId).subscribe(poslodavac => {
                this.poslodavac = poslodavac;
            });
        });
    }
    ngOnInit() {
    }
};
PoslodavacOglasComponent = __decorate([
    Component({
        selector: 'app-poslodavac-oglas',
        templateUrl: './poslodavac-oglas.component.html',
        styleUrls: ['./poslodavac-oglas.component.css']
    })
], PoslodavacOglasComponent);
export { PoslodavacOglasComponent };
//# sourceMappingURL=poslodavac-oglas.component.js.map