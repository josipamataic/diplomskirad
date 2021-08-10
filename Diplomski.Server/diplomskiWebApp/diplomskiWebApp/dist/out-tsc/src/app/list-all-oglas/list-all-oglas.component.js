import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ListAllOglasComponent = class ListAllOglasComponent {
    constructor(oglasService, router) {
        this.oglasService = oglasService;
        this.router = router;
        this.industrije = [];
    }
    ngOnInit() {
        this.fetchIndustrije();
        this.fetchOglasi();
    }
    fetchOglasi() {
        this.oglasService.getAllOglasi().subscribe(oglasi => {
            this.oglasiConst = oglasi;
            this.oglasi = oglasi;
            console.log(this.oglasi);
        });
    }
    fetchIndustrije() {
        this.oglasService.getIndustrije().subscribe(industrija => {
            this.industrije = industrija;
            console.log(this.industrije);
        });
    }
    filterByIndustrija(indId) {
        if (indId == 616) {
            this.oglasi = this.oglasiConst;
        }
        else {
            this.oglasi = this.oglasiConst.filter(p => p.industrijaId == indId);
        }
    }
};
ListAllOglasComponent = __decorate([
    Component({
        selector: 'app-list-all-oglas',
        templateUrl: './list-all-oglas.component.html',
        styleUrls: ['./list-all-oglas.component.css']
    })
], ListAllOglasComponent);
export { ListAllOglasComponent };
//# sourceMappingURL=list-all-oglas.component.js.map