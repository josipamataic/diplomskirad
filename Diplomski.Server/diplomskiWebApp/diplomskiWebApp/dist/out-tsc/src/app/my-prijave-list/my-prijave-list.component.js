import { __decorate } from "tslib";
import { Component } from '@angular/core';
let MyPrijaveListComponent = class MyPrijaveListComponent {
    constructor(oglasService, router, toastrService) {
        this.oglasService = oglasService;
        this.router = router;
        this.toastrService = toastrService;
    }
    ngOnInit() {
        this.fetchPrijave();
    }
    fetchPrijave() {
        this.oglasService.getMyPrijave().subscribe(prijave => {
            this.prijave = prijave;
        });
    }
    deletePrijava(id) {
        this.oglasService.deletePrijava(id).subscribe(res => {
            this.toastrService.success("Prijava uspješno obrisana.");
            this.fetchPrijave();
        });
    }
};
MyPrijaveListComponent = __decorate([
    Component({
        selector: 'app-my-prijave-list',
        templateUrl: './my-prijave-list.component.html',
        styleUrls: ['./my-prijave-list.component.css']
    })
], MyPrijaveListComponent);
export { MyPrijaveListComponent };
//# sourceMappingURL=my-prijave-list.component.js.map