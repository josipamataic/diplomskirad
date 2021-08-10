import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ListPoslodavciComponent = class ListPoslodavciComponent {
    constructor(poslodavacService, router) {
        this.poslodavacService = poslodavacService;
        this.router = router;
    }
    ngOnInit() {
        this.fetchPoslodavci();
    }
    fetchPoslodavci() {
        this.poslodavacService.getPoslodavci().subscribe(res => {
            this.poslodavci = res;
        });
    }
};
ListPoslodavciComponent = __decorate([
    Component({
        selector: 'app-list-poslodavci',
        templateUrl: './list-poslodavci.component.html',
        styleUrls: ['./list-poslodavci.component.css']
    })
], ListPoslodavciComponent);
export { ListPoslodavciComponent };
//# sourceMappingURL=list-poslodavci.component.js.map