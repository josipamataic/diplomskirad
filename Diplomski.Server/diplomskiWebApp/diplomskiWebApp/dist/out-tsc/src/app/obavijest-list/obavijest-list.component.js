import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ObavijestListComponent = class ObavijestListComponent {
    constructor(oglasService, router) {
        this.oglasService = oglasService;
        this.router = router;
    }
    ngOnInit() {
        this.fetchObavijesti();
    }
    fetchObavijesti() {
        this.oglasService.getObavijesti().subscribe(res => {
            this.obavijesti = res;
        });
    }
};
ObavijestListComponent = __decorate([
    Component({
        selector: 'app-obavijest-list',
        templateUrl: './obavijest-list.component.html',
        styleUrls: ['./obavijest-list.component.css']
    })
], ObavijestListComponent);
export { ObavijestListComponent };
//# sourceMappingURL=obavijest-list.component.js.map