import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ListKandidatiComponent = class ListKandidatiComponent {
    constructor(kandidatService) {
        this.kandidatService = kandidatService;
    }
    ngOnInit() {
        this.fetchKandidati();
    }
    fetchKandidati() {
        this.kandidatService.getKandidati().subscribe(res => {
            this.kandidati = res;
        });
    }
};
ListKandidatiComponent = __decorate([
    Component({
        selector: 'app-list-kandidati',
        templateUrl: './list-kandidati.component.html',
        styleUrls: ['./list-kandidati.component.css']
    })
], ListKandidatiComponent);
export { ListKandidatiComponent };
//# sourceMappingURL=list-kandidati.component.js.map